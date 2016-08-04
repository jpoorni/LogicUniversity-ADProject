using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class DelegateEmployeeDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();

        public void startDelegation(delegateEmployee demp)
        {
           context.delegateEmployees.Add(demp);
           context.SaveChanges();
        }
        //public void endDelegatEmployee(delegateEmployee demp, string departCode)
        //{
        //    delegateEmployee delegatedEmployee = (from e in context.employees
        //                                          join de in context.delegateEmployees
        //                                          on e.employeeId equals de.employeeId
        //                                          where e.departmentCode == departCode && de.status == "Open"
        //                                          select de).First();
        //    delegatedEmployee.status = "Closed";
        //    context.SaveChanges();

        //}

        public void endDelegation(delegateEmployee dee, int delegateId)
        {
            context.delegateEmployees.Where(de => de.delegationId == delegateId && de.employeeId == dee.employeeId).First().status = "Close";
            context.SaveChanges();
        }

        public delegateEmployee getDelegatedEmployee(int empid)
        {
            return context.delegateEmployees.Where(de => de.employeeId == empid).First();
        } 
        public delegateEmployee getDelegatedEmployee(string departCode)
        {
            delegateEmployee delegateEmployee = (from e in context.employees
                                                 join de in context.delegateEmployees
                                                 on e.employeeId equals de.employeeId
                                                 where e.departmentCode == departCode && de.status == "Open"
                                                 select de).First();
            return delegateEmployee;
        }
        //public string getStartDate(delegateEmployee demp)
        //{
        //    delegateEmployee demployee= context.delegateEmployees.Where(e => e.employeeId == demp.employeeId).First();
        //    string startDate = demp.fromDate.ToString();
        //    return startDate;
        //}
        //public string getEndDate(delegateEmployee demp)
        //{
        //    delegateEmployee demployee = context.delegateEmployees.Where(e => e.employeeId == demp.employeeId).First();
        //    string endDate = demp.toDate.ToString();
        //    return endDate;
        //}
        //public string getReason(delegateEmployee demp)
        //{
        //    delegateEmployee demployee = context.delegateEmployees.Where(e => e.employeeId == demp.employeeId).First();
        //    string reason = demp.reason;
        //    return reason;
        //}

        public bool checkDelegatedEmployee(string departCode)
        {
            List<delegateEmployee> delegateEmp = (from e in context.employees
                                                 join de in context.delegateEmployees
                                                 on e.employeeId equals de.employeeId
                                                 where e.departmentCode == departCode && de.status =="Open"
                                                 select de).ToList();
            if (delegateEmp.Count == 0)
            {
                return true;
            }
            else
                return false; 
        }

        public int findEmpCode(string empname)
        {
            return context.employees.Where(x => x.employeeName == empname).First().employeeId;
        }

        public void endDelegationForMobile(/*delegateEmployee dee,*/ int delegateId)
        {
            context.delegateEmployees.Where(de => de.delegationId == delegateId /*&& de.employeeId == dee.employeeId*/).First().status = "Close";
            context.SaveChanges();
        }
    }
}