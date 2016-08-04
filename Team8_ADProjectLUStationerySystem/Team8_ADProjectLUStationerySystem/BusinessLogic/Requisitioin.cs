using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class Requisitioin
    {
      
        DAO.RequisitionDAO RDAO = new DAO.RequisitionDAO();
        DAO.MailController MailC = new DAO.MailController();
        
        public void addrequisition(string deptcode, int empid, int sid, DateTime dateTime, bool selfreq, List<requisitionDetail> listrd)//new re
        {
            RDAO.createRequisition(deptcode, empid, sid, dateTime, selfreq, listrd);
            MailC.newRequisitionNotiForDH(deptcode);

           
        }
        public void changeStatus(int rid, int status)//aprove
        {
            RDAO.changeStatus(rid, status);
            if (status == 2001)
            {
                MailC.newRequisitionNotiForClerk();
                MailC.approveRequisitionNoti(rid);
            }
            else
            {
                MailC.noapproveRequisitionNoti(rid);
            }

        }

        public void editRequisitionById(int rid, string itemCode, int osq)
        {
            RDAO.editRequisitionById(rid, itemCode, osq);
        }

        //Employee
        public List<Models.RequisitionModel> employeeAllRequisition(int eid)
        {
            return RDAO.employeeAllRequisition(eid);
        }

        public List<Models.RequisitionModel> employeeRequisitionByStatus(int eid, int status)
        {
            return RDAO.employeeRequisitionByStatus(eid,status);
        }

        public List<Models.RequisitionModel> employeeRequisitionByMonth(int eid, int month)
        {

            return RDAO.employeeRequisitionByMonth(eid,month);
        }

        public List<Models.RequisitionModel> employeeRequisitionByAll(int eid, int status, int month)
        {
            return RDAO.employeeRequisitionByAll(eid,status, month);
        }

        //DOH

        public List<Models.RequisitionModel> getAllRequisition(string deptcode)
        {
            return RDAO.getAllRequisition(deptcode);
        }

        public List<Models.RequisitionModel> getRequisitionByStatus(string deptcode, int status)
        {
            return RDAO.getRequisitionByStatus(deptcode,status);
        }

        public List<Models.RequisitionModel> getRequisitionByMonth(string deptcode, int month)
        {

            return RDAO.getRequisitionByMonth(deptcode,month);
        }

        public List<Models.RequisitionModel> getRequisitionByAll(string deptcode, int status, int month)
        {
            return RDAO.getRequisitionByAll(deptcode,status, month);
        }
        public List<requisitionDetail> getDetails(int rid)
        {
            return RDAO.getDetails(rid);
        }


        public void editRequisitionByTable(List<requisitionDetail> detail)
        {
            foreach(requisitionDetail rdt in detail)
            {
                requisitionDetail dt = new requisitionDetail();
                dt.requisitionId = rdt.requisitionId;
                dt.itemCode = rdt.itemCode;
                dt.qtyNeeded = rdt.qtyNeeded;
                dt.qtyActual = rdt.qtyActual;
                dt.qtyOutstaning = rdt.qtyOutstaning;
                dt.outstandingField = rdt.outstandingField;
                RDAO.editRequisitionByTable(dt);
            }
        }


        List<requisitionDetail> updateItem;
        public List<requisitionDetail> addItem(int i, string itemCode, string itemDescription, int qtyNeeded, int qtyActual, int qtyOutstaning, bool outstandingField, List<requisitionDetail> listrd)
        {
            requisitionDetail rd = new requisitionDetail();
            rd.requisitionId = i;
            rd.itemCode = itemCode;
            rd.itemDescription = itemDescription;
            rd.qtyNeeded = qtyNeeded;
            rd.qtyActual = qtyActual;
            rd.qtyOutstaning = qtyOutstaning;
            rd.outstandingField = outstandingField;
            listrd.Add(rd);
            updateItem = listrd;
            return updateItem;
        }

        public List<Model.Requisitiondetails> ViewrequisionbyID(int empId)
        {
            return RDAO.ViewrequisionbyID(empId);
        }

        public List<Model.RequisitionView> Requisitionlist(int empId)
        {
            return RDAO.Requisitionlist(empId);
        }

        //Dept Head
       public List<Model.RequisitionView> Reqisitionview(string deptCode)
        {
            return RDAO.Viewemployee(deptCode);
        }

        public List<Model.Requisitiondetails> Viewrequisition(int reqID)
       {
           return RDAO.Viewrequisition(reqID);
       }

        public List<Model.RequisitionView> Viewreqbydept(string deptCode)
        {
            return RDAO.Viewreqbydept(deptCode);
        }

        //public List<Model.RequisitionView> Viewreqbydate(string deptCode)
        //{

        //   // return RDAO.Viewreqbydate(deptCode);
        //}

        public List<Model.RetriveViewbyCategory> TotalRetriveByCategory(int retId)
        {
            return RDAO.TotalRetriveByCategory(retId);
        }

        public List<Model.RetriveViewbyDept> RetriveByDept(int categoryId, int retId)
        {
            return RDAO.RetriveByDept(categoryId, retId);
        }




        public string findDeptCode(int userid)
        {
            return RDAO.findDeptCode(userid);
        }

        public List<Models.DisbursementModel> getfromtodates(int userid, DateTime from, DateTime to)
        {
            return RDAO.getfromtodates(userid, from, to);
        }

        public List<Models.DisbursementModel> deptfromtodates(string deptcode, DateTime from, DateTime to)
        {
            return RDAO.deptfromtodates(deptcode, from, to);
        }

        public List<Models.RequisitionModel> bindRequisition(string deptcode)
        {
            return RDAO.bindRequisition(deptcode);
        }

        public List<Models.RequisitionDetailsModel> bindRequisitionDetails(int reqid)
        {
            return RDAO.bindRequisitionDetails(reqid);
        }

        public List<requisition> getSearch(int status, int month)
        {
            return RDAO.getSearch(status, month);
        }
    }
}