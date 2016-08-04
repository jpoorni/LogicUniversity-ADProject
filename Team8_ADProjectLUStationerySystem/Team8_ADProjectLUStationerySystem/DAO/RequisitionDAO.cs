using Team8_ADProjectLUStationerySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class RequisitionDAO
    {
        logicUniversityEntities luentity;
        public RequisitionDAO()
        {
            luentity = new logicUniversityEntities();
        }
        //Create Requisition
        
        public void createRequisition(string deptcode, int empid, int sid, DateTime dateTime, bool selfreq, List<requisitionDetail> listrd)
        {
            requisition r = new requisition();
            r.departmentCode = deptcode;
            r.employeeId = empid;
            r.statusId = sid;
            r.requisitionDate = dateTime;
            r.selfCollection = selfreq;
            luentity.requisitions.Add(r);
            luentity.SaveChanges();
            int reqid = r.requisitionId;

            foreach (requisitionDetail reqd in listrd)
            {
                requisitionDetail dt = new requisitionDetail();
                dt.requisitionId = reqid;
                dt.itemCode = reqd.itemCode;
                dt.itemDescription = reqd.itemDescription;
                dt.qtyNeeded = reqd.qtyNeeded;
               
                dt.qtyActual = reqd.qtyActual;
                dt.qtyOutstaning = reqd.qtyOutstaning;
                dt.outstandingField = reqd.outstandingField;
                luentity.requisitionDetails.Add(dt);
                luentity.SaveChanges();
            }

        }
       


        //Update status after Approving

        public void changeStatus(int rid, int status)
        {
            requisition r = luentity.requisitions.Where(req => req.requisitionId == rid).FirstOrDefault();
            r.statusId = status;
            luentity.SaveChanges();
        }
        //after disbursement, any damage occue, only change the damage things.
        public void editRequisitionById(int rid, string itemCode, int osq)
        {
            requisition req = luentity.requisitions.Where(r => r.requisitionId == rid).FirstOrDefault();
            req.statusId = 1;

            requisitionDetail reqDt = luentity.requisitionDetails.Where(rd => rd.requisitionId == rid && rd.itemCode == itemCode).FirstOrDefault();
            reqDt.qtyOutstaning = osq;

            luentity.SaveChanges();

        }

       

        //Employee..

        public List<Models.RequisitionModel> employeeAllRequisition(int eid)
        {
            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.employeeId == eid
                     
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();
            //var query = from req in luentity.requisitions where req.employeeId==eid select req;
            //return query.ToList();
        }
        public List<Models.RequisitionModel> employeeRequisitionByStatus(int eid, int status)
        {
            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.employeeId == eid
                       where r.statusId == status
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();


            //return luentity.requisitions.Where(x => x.employeeId==eid && x.statusId == status).ToList();
        }

        public List<Models.RequisitionModel> employeeRequisitionByMonth(int eid, int month)
        {
            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.employeeId == eid
                       where r.requisitionDate.Value.Month == month
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();

           // return luentity.requisitions.Where(x =>x.employeeId==eid && x.requisitionDate.Value.Month == month).ToList();

        }

        
        public List<Models.RequisitionModel> employeeRequisitionByAll(int eid, int status, int month)
        {
            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.employeeId == eid
                       where r.statusId == status
                       where r.requisitionDate.Value.Month == month
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();

            //return luentity.requisitions.Where(r => r.employeeId==eid && r.statusId == status && r.requisitionDate.Value.Month == month).ToList();
        }

        //HOD
        public List<Models.RequisitionModel> getAllRequisition(string deptcode)
        {
            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.departmentCode== deptcode

                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();
            //var query = from req in luentity.requisitions where req.departmentCode == deptcode select req;
            //return query.ToList();
        }
        public List<Models.RequisitionModel> getRequisitionByStatus(string deptcode, int status)
        {

            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.departmentCode== deptcode
                       where r.statusId == status
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();

          // return luentity.requisitions.Where(x => x.departmentCode==deptcode && x.statusId == status).ToList();
        }

        public List<Models.RequisitionModel> getRequisitionByMonth(string deptcode, int month)
        {

            var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.departmentCode==deptcode
                       where r.requisitionDate.Value.Month == month
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();
          
           // return luentity.requisitions.Where(x => x.departmentCode==deptcode && x.requisitionDate.Value.Month == month).ToList();

        }

        public List<Models.RequisitionModel> getRequisitionByAll(string deptcode, int status, int month)
        {
             var list = from r in luentity.requisitions
                       from rs in luentity.requisitionStatus
                       where r.statusId == rs.statusId
                       where r.departmentCode==deptcode
                       where r.statusId == status
                       where r.requisitionDate.Value.Month == month
                       select new Models.RequisitionModel
                       {
                           RequisitionId = r.requisitionId,
                           RequisitionDate = (DateTime)r.requisitionDate,
                           StatusDescription = rs.statusDescription

                       };

            return list.ToList();
            //return luentity.requisitions.Where(r => r.departmentCode==deptcode && r.statusId == status && r.requisitionDate.Value.Month == month).ToList();
        }

        public  List<requisitionDetail> getDetails(int rid)
        {
            return luentity.requisitionDetails.Where(r => r.requisitionId == rid).ToList();
        }

        public void editRequisitionByTable(requisitionDetail detail)
        {
            luentity.requisitionDetails.Add(detail);
            luentity.SaveChanges();
        }

        public int getReqId(string deptcode, int empid, int sid, DateTime dateTime, bool selfreq)
        {
            throw new NotImplementedException();
        }

        //JSON for Emplopyee

        public List<Model.Requisitiondetails> ViewrequisionbyID(int reqID)
        {


            var list = from r in luentity.requisitions
                       from rd in luentity.requisitionDetails
                       from rs in luentity.requisitionStatus
                       from c in luentity.catelogueItems
                       where r.requisitionId == rd.requisitionId
                       where rd.itemCode == c.itemCode
                       where r.statusId == rs.statusId
                       where rd.requisitionId == reqID
                       select new Model.Requisitiondetails { itemDescription = c.itemDescription, qtyNeeded = rd.qtyNeeded,qtyAcutal=rd.qtyActual, statusDescription = rs.statusDescription };
            return list.ToList();

           
        }

       

        public List<Model.RequisitionView> Requisitionlist(int empid)
        {
            var list = from r in luentity.requisitions
                       from rd in luentity.requisitionDetails
                       where r.requisitionId == rd.requisitionId
                       where r.employeeId == empid
                       group rd by new {r.requisitionId,r.requisitionDate} into d
                       select new Model.RequisitionView
                       {
                           requisitionId=d.Key.requisitionId,
                           requisitionDate = (DateTime)d.Key.requisitionDate,
                           totalQty = d.Sum(rd => rd.qtyNeeded),
                       };

                       return list.ToList();

        }

        //JSON for DepHead:

        public List<Model.RequisitionView> Viewemployee(string deptCode)
        {
            var list = from r in luentity.requisitions
                       from e in luentity.employees
                       from rs in luentity.requisitionStatus
                       where r.employeeId == e.employeeId
                       where r.departmentCode == deptCode
                       where r.statusId==rs.statusId
                      where r.statusId == 2000
                       select new Model.RequisitionView
                       {
                           requisitionId = r.requisitionId,
                           employeeID = r.employeeId,
                           employeeName = e.employeeName,
                           requisitionDate=(DateTime)r.requisitionDate,
                           statusDescription=rs.statusDescription

                       };
            return list.ToList();
        }

        public List<Model.Requisitiondetails> Viewrequisition(int reqID)
        {
            var list = from rd in luentity.requisitionDetails
                       from c in luentity.categories
                       from ca in luentity.catelogueItems
                       where rd.itemCode == ca.itemCode
                       where ca.categoryId == c.categoryId
                       where rd.requisitionId == reqID
                       select new Model.Requisitiondetails
                       {
                           category = c.categoryName,
                           itemDescription = ca.itemDescription,
                           qtyNeeded = rd.qtyNeeded,
                       };
            return list.ToList();
        }





        public List<Model.RequisitionView> Viewreqbydept(string deptCode)
        {
            var list = from r in luentity.requisitions
                       from e in luentity.employees
                       from rs in luentity.requisitionStatus
                       where r.employeeId == e.employeeId
                       where r.statusId == rs.statusId
                      // where r.requisitionDate <=  DateTime.Now.Date.AddDays(-3) && r.requisitionDate >= DateTime.Now.Date.AddDays(30)
                       where r.departmentCode == deptCode
                      

                       select new Model.RequisitionView
                       {
                           requisitionId = r.requisitionId,
                           employeeID = r.employeeId,
                           employeeName = e.employeeName,
                           requisitionDate = (DateTime)r.requisitionDate,
                           statusDescription = rs.statusDescription

                       };
            return list.ToList();
        }

        public List<Model.RetriveViewbyCategory> TotalRetriveByCategory(int retId)
        {
            var list = from rd in luentity.retrievalDetails
                       from c in luentity.categories
                       from ci in luentity.catelogueItems
                       where rd.itemCode == ci.itemCode
                       where ci.categoryId == c.categoryId
                       where rd.retrievalId == retId
                       group rd by new { c.categoryId, c.categoryName } into d
                       select new Model.RetriveViewbyCategory
                       {
                           categoryId = d.Key.categoryId,
                           categoryName = d.Key.categoryName,
                           actualQuantity = d.Sum(rd => rd.actualQuantity),
                       };
            return list.ToList();
        }

        public List<Model.RetriveViewbyDept> RetriveByDept(int categoryId, int retId)
        {
            var list = from d in luentity.departments
                       from c in luentity.categories
                       from ci in luentity.catelogueItems
                       from rd in luentity.retrievalDetails
                       where ci.categoryId == c.categoryId
                       where d.departmentCode == rd.departmentId
                       where rd.itemCode == ci.itemCode
                       where c.categoryId == categoryId
                       where rd.retrievalId == retId
                       group rd by new { rd.retrievalId, rd.departmentId, d.departmentName, ci.itemCode, ci.itemDescription } into d
                       select new Model.RetriveViewbyDept
                       {
                           retrievalId = d.Key.retrievalId,
                           departmentId = d.Key.departmentId,
                           depetName = d.Key.departmentName,
                           itemCode = d.Key.itemCode,
                           itemDescription = d.Key.itemDescription,
                           actualQuantity = d.Sum(rd => rd.actualQuantity)
                       };
            return list.ToList();
        }

        public  string findDeptCode(int userid)
        {
            return luentity.employees.Where(e => e.employeeId == userid).FirstOrDefault().departmentCode;
        }

        public List<Models.DisbursementModel> getfromtodates(int userid, DateTime fromdate, DateTime todate)
        {
            //return luentity.disbursements.Where(d => d.employeeId == userid && d.collectionDate>=fromdate && d.collectionDate<=todate).ToList();

            var list = from d in luentity.disbursements
                       from dp in luentity.departments
                       where d.departmentCode == dp.departmentCode
                       where d.employeeId == userid
                       where d.collectionDate >= fromdate && d.collectionDate <= todate
                       select new Models.DisbursementModel
                       {
                           DisbursementId = d.disbursementId,
                           DepartmentName = dp.departmentName,
                           CollectionDate = (DateTime) d.collectionDate
                       };
            return list.ToList();
        }


        public List<Models.DisbursementModel> deptfromtodates(string deptcode, DateTime fromdate, DateTime todate)
        {
           // return luentity.disbursements.Where(d => d.departmentCode == deptcode && d.collectionDate >= fromdate && d.collectionDate <= todate).ToList();

            var list = from d in luentity.disbursements
                       from dp in luentity.departments
                       where d.departmentCode == dp.departmentCode
                       where d.departmentCode == deptcode
                       where d.collectionDate >= fromdate && d.collectionDate <= todate
                       select new Models.DisbursementModel
                       {
                           DisbursementId = d.disbursementId,
                           DepartmentName = dp.departmentName,
                           CollectionDate = (DateTime)d.collectionDate
                       };
            return list.ToList();
        }

        public List<Models.RequisitionModel> bindRequisition(string deptcode)
        {
            //return luentity.requisitions.Where(r => r.departmentCode == deptcode && r.statusId == 2000).ToList();

            var list = from r in luentity.requisitions
                       from e in luentity.employees
                       where r.employeeId == e.employeeId
                       where r.departmentCode == deptcode
                       where r.statusId == 2000
                       select new Models.RequisitionModel
                       {
                           RequisitionId=r.requisitionId,

                           EmployeeName = e.employeeName,
                           RequisitionDate = (DateTime)r.requisitionDate
                       };
            return list.ToList();
        }

        public List<Models.RequisitionDetailsModel> bindRequisitionDetails(int reqid)
        {
            var list = from rd in luentity.requisitionDetails
                       from ca in luentity.catelogueItems
                       where rd.itemCode == ca.itemCode
                       where rd.requisitionId == reqid

                       select new Models.RequisitionDetailsModel
                       {
                           ItemDescription = ca.itemDescription,
                           Quantity =(int)rd.qtyNeeded,
                           Uom = ca.uom
                       };
            return list.ToList();
           // return luentity.requisitionDetails.Where(rd => rd.requisitionId == reqid).ToList();
        }

        public List<requisition> getSearch(int status, int month)
        {
            if (status != 0 && month != 0)
            {
                return luentity.requisitions.Where(x =>
                  x.statusId == status &&
                  x.requisitionDate.Value.Month == month).ToList();

            }
            else if (status == 0 && month != 0)
            {
                return luentity.requisitions.Where(x =>
                     x.requisitionDate.Value.Month == month).ToList();


            }
            else if (status == 0 && month == 0)
            {
                return luentity.requisitions.ToList();


            }
            else
            {
                return luentity.requisitions.Where(x =>
                  x.statusId == status).ToList();

            }
              
        }
    }
}