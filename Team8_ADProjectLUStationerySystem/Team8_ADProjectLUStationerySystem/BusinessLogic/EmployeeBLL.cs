using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class EmployeeBLL
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();

        public List<employee> employeeByDepartment(string departCode)
        {
            List<employee> elist= employeeDAO.getEmployeeByDepartmentCode(departCode);
            return elist;
        }
        public List<employee> getNormalEmployeeByDepartmentCode(string departCode)
        {
            return employeeDAO.getNormalEmployeeByDepartmentCode(departCode);
        }

        public employee getEmployeeByEmpId(int eid)
        {
            employee e = employeeDAO.getEmployeeByEmployeeId(eid);
            return e;
        }
        public string getDepartmentCode(int eid)
        {
            string departCode = employeeDAO.getDepartmentCode(eid);
            return departCode;
        }

        public List<department> getAlldepartment()
        {
            return employeeDAO.getAllDep();
        }
        public List<string> getAllClerks()
        {
            return employeeDAO.getAllClerks();
        }
        public List<employee> getAllEmployeesformobile(string dcode)
        {
            return employeeDAO.getAllEmployeesformobile(dcode);
        }

        public employee getEmployee(int empid)
        {
            return employeeDAO.getEmployee(empid);
        }

        public Model.DelegateEmployee currentDelegate(string deptcode)
        {
            return employeeDAO.currentDelegate(deptcode);
        }
    }
}