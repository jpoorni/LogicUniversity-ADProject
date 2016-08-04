using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class LoginDAO
    {
        logicUniversityEntities cntx = new logicUniversityEntities();
        userDetail user;
        public int login(int userid, string passWord)
        {
            Boolean isExsitedUser = false;
            Boolean isCorrectPasswrod = false;
            try
            {
                user = cntx.userDetails.Where(u => u.userId == userid).First();
            }
            catch
            {
                user = null;
            }


            if (user != null)
            {
                isExsitedUser = true;
                if (user.password == passWord)
                {
                    isCorrectPasswrod = true;
                }
                else
                    isCorrectPasswrod = false;
            }

            if (isExsitedUser && isCorrectPasswrod)
            {
                userDetail loginUser = cntx.userDetails.Where(x => x.userId == userid && x.password == passWord).First();
                if (loginUser.roleId.HasValue)
                {
                    return loginUser.roleId.Value;
                }
                else
                {
                    return 0;
                }

            }
            else return 0;
        }

        public Model.Login loginformobile(string uname, string pwd)
        {
            var list = from e in cntx.employees
                       from u in cntx.userDetails
                       from r in cntx.roles
                       from d in cntx.departments
                       where e.employeeId == u.userId
                       where u.roleId == r.roleId
                       where e.departmentCode == d.departmentCode
                       where e.employeeName == uname
                       where u.password == pwd
                       select new Model.Login
                       {
                           username = e.employeeName,
                           password = u.password,
                           userId = u.userId,
                           roleId = r.roleId,
                           roleDescription = r.roleDescription,
                           departmentCode = d.departmentCode,
                           departmentName = d.departmentName
                       };
            return list.FirstOrDefault();
        }
    }
}