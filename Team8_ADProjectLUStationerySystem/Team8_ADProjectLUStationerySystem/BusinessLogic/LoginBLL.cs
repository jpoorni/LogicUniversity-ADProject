using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class LoginBLL
    {
        LoginDAO loginDAO = new LoginDAO(); 
        UserBLL userlogic = new UserBLL();

        string error = "errorPage.aspx";
        //string sc = "storeClerkLogin.aspx";
        string sc = "~/StoreClerk1/NewRequisitionList.aspx";
        string sc2 = "~/StoreClerk1/RetrievalList.aspx";
        //string sp = "storeSupervisorLogin.aspx";
        string sp = "~/StoreSupervisor/OrderListForApproval";
        string sm = "~/StoreManager/ApproveInventoryAdjustmentBymgr";
        string dh = "~/DepartmentHead/ApproveRequisitions.aspx";
        string employee = "~/Employee/CreateRequisition.aspx";

        public string login(string userName, string pw)
        {
            int id = userlogic.CheckUser(userName.ToLower().Trim());

            int i = loginDAO.login(id, pw);


            if (i == 11000)
            {
                return sc;
            }
            else if (i == 11001)
            {
                return sp;
            }
            else if (i == 11002)
            {
                return sm;
            }
            else if (i == 11003 || i == 11006)
            {
                return dh;
            }
            else if (i == 11004 || i == 11005)
            {
                return employee;
            }
            else
            {
                return error;
            }
        }

        public Model.Login loginformobile(string uname, string pwd)
        {
            return loginDAO.loginformobile(uname, pwd);
        }
    }
}