
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class UserBLL
    {
        UserDAO userDAO = new UserDAO();
        public int getUserRoleByUserid(int id)
        {
            return userDAO.getUserRoleByUserid(id);
        }
        public userDetail GetUserByID(int userid)
        {
            return userDAO.getUserByID(userid);
        }

        public int CheckUser(string userName)
        {
            employee emp = userDAO.checkUser(userName);
            if (emp != null)
                return emp.employeeId;
            else
                return 0;
        }

        public void changeDelegateEmployeeUserRoleId(int eid, int roleId)
        {
            userDAO.changeDelegateEmployeeUserRoleId(eid, roleId);
        }

        public Boolean CorrectUser(int userid)
        {
            int roleid = userDAO.getUserRoleByUserid(userid);
            if (roleid != 11001)
                return false;
            else
                return true;
        }
    }
}