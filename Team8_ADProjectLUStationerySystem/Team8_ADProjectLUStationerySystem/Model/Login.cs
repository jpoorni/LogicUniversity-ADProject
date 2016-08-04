using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class Login
    {
        public string username;
        public string password;
        public int userId;
        public int roleId;
        public string roleDescription;
        public string departmentCode;
        public string departmentName;

        public Login()
        {

        }

        public Login(string username, string password, int userId, int roleId, string roleDescription, string departmentCode, string departmentName)
        {
           this.username=username;
            this.password=password;
            this.userId=userId;
            this.roleId=roleId;
            this.roleDescription=roleDescription;
            this.departmentCode=departmentCode;
            this.departmentName=departmentName;
        }



        public string Username { get; set; }

        public string Password { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleDescription { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

    }
}