using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class DelegateEmployeeBLL
    {
        DelegateEmployeeDAO delegateEmployee = new DelegateEmployeeDAO();

        public void EndDelegation(delegateEmployee dee, int delegateId)
        {
            delegateEmployee.endDelegation(dee, delegateId);
        }

        public void startDelegatation(delegateEmployee demp)
        {
            delegateEmployee.startDelegation(demp);
        }
        //public void endDelegatEmployee(delegateEmployee demp, string departCode)
        //{
        //    delegateEmployee.endDelegatEmployee(demp, departCode);
        //}

        public delegateEmployee GetDelegatedEmployee(int empid)
        {
            return delegateEmployee.getDelegatedEmployee(empid);
        }
        public delegateEmployee getDelegatedEmployee(string departCode)
        {
            return delegateEmployee.getDelegatedEmployee(departCode);
        }
        //public string getStartDate(delegateEmployee demp)
        //{
        //    return delegateEmployee.getStartDate(demp);
        //}
        //public string getEndDate(delegateEmployee demp)
        //{
        //    return delegateEmployee.getEndDate(demp);
        //}
        //public string getReason(delegateEmployee demp)
        //{
        //    return delegateEmployee.getReason(demp);
        //}
        public bool checkDelegatedEmployee(string departCode)
        {
           return delegateEmployee.checkDelegatedEmployee(departCode);  
        }

        public int findEmpCode(string empname)
        {
            return delegateEmployee.findEmpCode(empname);
        }

        public void endDelegationForMobile(int delegateId)
        {
            delegateEmployee.endDelegationForMobile(delegateId);
        }
        
    }
}