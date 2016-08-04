using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class DelegateEmployee
    {

        public int employeeId;
        public string employeeName;
        public string status;


        public DelegateEmployee()
        {

        }

        public DelegateEmployee(int employeeId,string employeeName,string status)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.status = status;
        }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Status { get; set; }
    }
}