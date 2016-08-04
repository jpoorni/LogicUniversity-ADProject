using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class EmployeeDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();

        public List<employee> getEmployeeByDepartmentCode(string departCode)
        {
            return context.employees.Where(e => e.departmentCode == departCode).ToList();
        }

        public List<employee> getNormalEmployeeByDepartmentCode(string departCode)
        {
            department dep = context.departments.Where(x=>
                x.departmentCode==departCode).First();
            return context.employees.Where(e => 
                e.departmentCode == departCode &&
                e.employeeName!=dep.headName).ToList();
        }
        public employee getEmployeeByEmployeeId(int eid)
        {
            return context.employees.Where(e => e.employeeId == eid).First();
        }
        public string getDepartmentCode(int eid)
        {
            employee emp = context.employees.Where(e => e.employeeId == eid).First();
            string departCode = emp.departmentCode;
            return departCode;
        }

        public List<department> getAllDep()
        {
            return context.departments.Where(x =>
                x.departmentCode != "STOR").ToList();
        }

        public List<string> getAllClerks()
        {
            var list = from emp in context.employees
                       from u in context.userDetails
                       where emp.employeeId == u.userId
                       where u.roleId == 11000
                       select emp.employeeName;
            return list.ToList();
        }

        public List<employee> getAllEmployeesformobile(string depcode)
        {
            var query = from emp in context.employees
                        from ud in context.userDetails
                        where emp.departmentCode == depcode
                        where emp.employeeId == ud.userId
                        where ud.roleId == 11004

                        select emp;
            return query.ToList();
        }

        public employee getEmployee(int empid)
        {
            var query = from emp in context.employees
                        where emp.employeeId == empid
                        select emp;
            return query.FirstOrDefault();
        }

        public Model.DelegateEmployee currentDelegate(string deptcode)
        {
            //var list = from d in luentity.delegateEmployees
            //           from e in luentity.employees
            //           where d.employeeId == e.employeeId
            //           where e.departmentCode == deptcode
            //          // where d.status == "Open"
            //           select new Model.Delegate
            //           {
            //               employeeId = d.employeeId,
            //               employeeName = e.employeeName,
            //               status = d.status

            //           };
            //return list.FirstOrDefault();
            DelegateEmployeeDAO a = new DelegateEmployeeDAO();
            if (a.checkDelegatedEmployee(deptcode) == false)
            {
                var list = (from d in context.employees
                            from de in context.delegateEmployees
                            where d.employeeId == de.employeeId
                            where d.departmentCode == deptcode
                            where de.status == "Open"
                            select new Model.DelegateEmployee
                            {
                                // EmployeeId = (int) de.employeeId,
                                employeeId = (int)de.employeeId,
                                // EmployeeName = d.employeeName,
                                employeeName = d.employeeName,
                                // Status = de.status,
                                status = de.status,
                            }).First();
                return list;
            }
            else
            {
                return new Model.DelegateEmployee(0, "", "");
            }
        }
        
       
    }
}