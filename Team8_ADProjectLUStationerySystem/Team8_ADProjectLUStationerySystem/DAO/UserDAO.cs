using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class UserDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();
        public int getUserRoleByUserid(int id)
        {
            var role = from u in context.userDetails
                       where u.userId == id
                       select (new { u.roleId });
            return Convert.ToInt32(role);
        }
        public userDetail getUserByID(int userid)
        {
            return context.userDetails.Where(u => u.userId == userid).First();
        }

        public employee checkUser(string userName)
        {
            try
            {
                return context.employees.Where(e => e.employeeName == userName).First();
            }
            catch
            {
                return null;
            } 
        }
        public int getUserRoleId(int userid)
        {
            var roleId = from e in context.userDetails
                         where e.userId == userid
                         select e.roleId;

            return Convert.ToInt32(roleId);
        }
        public void changeDelegateEmployeeUserRoleId(int eid, int roleId)
        {
            context.userDetails.Where(u => u.userId == eid).First().roleId = roleId;
            context.SaveChanges();
        }
    }
}