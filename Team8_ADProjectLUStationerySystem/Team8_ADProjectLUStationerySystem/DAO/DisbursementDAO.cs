using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class DisbursementDAO
    {
        public void changeRetrievalStatus(int retrievalId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disid = from x in luSSEntity.disbursements
                        where x.RetrivalId == retrievalId
                        select x.disbursementId;
            List<int> ids = disid.ToList();
            var retDep = from x in luSSEntity.retrievalDetails
                         where x.retrievalId == retrievalId
                         group x.departmentId by x.departmentId into g
                         select new { departmentId = g.ToList() };
            int num = retDep.Count();
            if (ids.Count >= num)
            {
                var retrieval = from x in luSSEntity.retrievals
                                where x.retrievalId == retrievalId
                                select x;
                foreach (var x in retrieval)
                {
                    x.status = "2";

                }
                luSSEntity.SaveChanges();
            }

        }
        public void changeRequisitionStatus(string departmentCode, int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var req = from x in luSSEntity.requisitions
                      from y in luSSEntity.requisitionStatus
                      from z in luSSEntity.retrievalRequisitions
                      from w in luSSEntity.disbursements
                      where w.disbursementId == disbursementId
                      where w.RetrivalId == z.retrievalId
                      where x.requisitionId == z.requisitionId
                      where y.statusDescription == "Retrieval-Confirm"
                      where x.statusId == y.statusId
                      where x.departmentCode == departmentCode
                      select x;
            List<requisition> reqs = req.ToList();
            foreach (requisition r in reqs)
            {
                r.statusId = 2006;
            }
            luSSEntity.SaveChanges();
        }//
        public void generateDisbursementList(string departmentId, int retrievalId, DateTime collectionDate)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var olddisbursement = from x in luSSEntity.disbursements
                                  where x.departmentCode == departmentId
                                  where x.RetrivalId == retrievalId
                                  where x.collectionDate == collectionDate
                                  select x;
            foreach (var x in olddisbursement)
            {
                luSSEntity.disbursements.Remove(x);
            }
            luSSEntity.SaveChanges();
            //if(tempids.Count>0)
            //{
            //    for (int i = 0; i < tempids.Count; i++)
            //    {
            //        int id=tempids.ElementAt(i);
            //        var removeDisbursement = from w in luSSEntity.disbursements
            //                                 where w.disbursementId == id
            //                                 select w;
            //        foreach(var w in removeDisbursement)
            //        {
            //            luSSEntity.disbursements.Remove((disbursement)w);
            //        }
            //        luSSEntity.SaveChanges();
            //    }
            //}
            var disbursement = from x in luSSEntity.departments
                               //from y in luSSEntity.employees
                               where x.departmentCode == departmentId
                               //where y.employeeName==x.RepresentativeName
                               select x;
            //string point = null;
            var retrieval = from y in luSSEntity.retrievals
                            where y.retrievalId == retrievalId
                            select y;
            foreach (var y in retrieval)
            {
                if (y.status == "1")
                {
                    disbursement newDisbursement = new disbursement();
                    foreach (var x in disbursement)
                    {
                        newDisbursement.collectionId = x.collectionPointId;
                        //point = Convert.ToString(x.collectionPointId);
                        newDisbursement.employeeId = x.RepresentativeID;
                    }
                    newDisbursement.departmentCode = departmentId;
                    newDisbursement.collectionDate = collectionDate;
                    newDisbursement.status = "WithoutDetails";
                    newDisbursement.RetrivalId = retrievalId;
                    luSSEntity.disbursements.Add(newDisbursement);
                    
                }
            }
            luSSEntity.SaveChanges();
        }//
        public int generateDisbursementDetail(string departmentId, int retrievalId, DateTime collectionDate)
        {
            int disnumber = 0;
            List<Model.disbursement> details = new List<Model.disbursement>();
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var dDetail = from y in luSSEntity.retrievalDetails
                          from z in luSSEntity.retrievals
                          where z.retrievalId == retrievalId
                          where y.retrievalId == z.retrievalId
                          where y.departmentId == departmentId
                          where z.status == "1"
                          select new { itemCode = y.itemCode, reqQuantity = y.actualQuantity };
            foreach (var y in dDetail)
            {
                details.Add(new Model.disbursement(y.itemCode, Convert.ToInt32(y.reqQuantity)));
                Console.WriteLine(y.itemCode);
            }
            var disnum = from x in luSSEntity.disbursements
                         where x.departmentCode == departmentId
                         where x.collectionDate == collectionDate
                         where x.status == "WithoutDetails"
                         select x;
            foreach (var x in disnum)
            {
                disnumber = x.disbursementId;
                x.status = "0";
            }
            changeRequisitionStatus(departmentId, disnumber);
            for (int i = 0; i < details.Count; i++)
            {
                disbursementDetail newDisbursementDetail = new disbursementDetail();
                newDisbursementDetail.disbursementId = disnumber;
                newDisbursementDetail.itemCode = details[i].getItemCode();
                newDisbursementDetail.reqQuantity = details[i].getReqQuantity();
                newDisbursementDetail.receivedQuantity = details[i].getReqQuantity();
                newDisbursementDetail.marks = true;
                luSSEntity.disbursementDetails.Add(newDisbursementDetail);
                luSSEntity.SaveChanges();
                //changeRetrievalStatus(retrievalId);
            }
            return disnumber;
        }//
        public disbursement getDisbursement(int disbursemenId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursement = from x in luSSEntity.disbursements
                               where x.disbursementId == disbursemenId
                               select x;
            disbursement newdisbursement = new disbursement();
            foreach (var x in disbursement)
            {
                newdisbursement.disbursementId = x.disbursementId;
                newdisbursement.employeeId = x.employeeId;
                newdisbursement.collectionDate = x.collectionDate;
                newdisbursement.collectionId = x.collectionId;
                newdisbursement.departmentCode = x.departmentCode;
                newdisbursement.status = x.status;
                newdisbursement.RetrivalId = x.RetrivalId;
            }
            return newdisbursement;
        }
        public List<Models.disbursement> getDisbursementforMobile(string departmentCode)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursementforMObile = from x in luSSEntity.disbursements
                                        //from y in luSSEntity.employees
                                        where x.departmentCode == departmentCode
                                        where x.status == "0"
                                        //where x.employeeId == y.employeeId
                                        select x;
            List<disbursement> dis = disbursementforMObile.ToList();
            List<Models.disbursement> disformobile = new List<Models.disbursement>();
            foreach (disbursement d in dis)
            {
                string name = d.employee.employeeName;
                string date = Convert.ToString(d.collectionDate);
                string photo = d.department.photos;
                int id = d.disbursementId;
                disformobile.Add(new Models.disbursement(id, name, date, photo));
            }
            return disformobile;
        }

        //3
        //public List<Models.disbursementdetails> getDisbursementDetailsListforMobile(int disbursementId)
        //{
        //    logicUniversityEntities luSSEntity = new logicUniversityEntities();
        //    var disbursementDetailsForMobile = from x in luSSEntity.disbursementDetails
        //                                       where x.disbursementId == disbursementId
        //                                       select x;
        //    List<disbursementDetail> details = disbursementDetailsForMobile.ToList();
        //    List<Models.disbursementdetails> detailsforMobile = new List<Models.disbursementdetails>();
        //    foreach (disbursementDetail d in details)
        //    {
        //        string itemName = d.catelogueItem.itemDescription;
        //        int qty = Convert.ToInt32(d.reqQuantity);
        //        detailsforMobile.Add(new Models.disbursementdetails(itemName, qty));
        //    }
        //    return detailsforMobile;
        //}
        public Model.disbursement getDisbursementDetailsforMobile(int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            Model.disbursement dis = null;
            var disbursementinfo = from x in luSSEntity.disbursements
                                   where x.disbursementId == disbursementId
                                   select x;
            foreach (var x in disbursementinfo)
            {
                string departmentname = x.department.departmentName;
                string repphoto = x.employee.photo;
                string repname = x.employee.employeeName;
                string collectiondes = x.collectionPoint.collectionPointName;
                string collectionDate = Convert.ToString(x.collectionDate);
                List<Model.disbursementdetails> details = getDisbursementDetailsListforMobile(disbursementId);
                dis = new Model.disbursement(departmentname, repphoto, repname, collectiondes, collectionDate, details);
            }
            return dis;
        }
        public List<disbursementDetail> getDisbursementDetail(int disbursemenId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursementDetail = from x in luSSEntity.disbursementDetails
                                     where x.disbursementId == disbursemenId
                                     select x;
            List<disbursementDetail> ddetails = disbursementDetail.ToList();
            return ddetails;
        }
        public void changeDisbursementDetail(int disbursementId, string itemCode, int realReceiveQty, string departmentCode)
        {
            int pendingQty = 0;
            int judgeQty = 0;
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursementDetail = from x in luSSEntity.disbursementDetails
                                     where x.disbursementId == disbursementId
                                     where x.itemCode == itemCode
                                     //new change
                                     //where x.marks==true
                                     select x;
            foreach (var x in disbursementDetail)
            {
                x.marks = false;
                pendingQty = Convert.ToInt32(x.receivedQuantity) - realReceiveQty;
                x.receivedQuantity = realReceiveQty;

            }
            luSSEntity.SaveChanges();
            var requisition1 = from x in luSSEntity.requisitionDetails
                               from y in luSSEntity.requisitions
                               from z in luSSEntity.requisitionStatus
                               from w in luSSEntity.disbursements
                               from a in luSSEntity.retrievalRequisitions
                               where w.disbursementId == disbursementId
                               where a.retrievalId == w.RetrivalId
                               where a.requisitionId == y.requisitionId
                               where x.itemCode == itemCode
                               where y.statusId == z.statusId
                               where z.statusDescription == "OutStanding"
                               where x.qtyOutstaning > 0
                               where y.departmentCode == departmentCode
                               where x.requisitionId == y.requisitionId
                               select x;
            foreach (var x in requisition1)
            {
                judgeQty = Convert.ToInt32(x.qtyActual);
                if (judgeQty >= pendingQty)
                {
                    x.qtyActual = judgeQty - pendingQty;
                    x.qtyOutstaning = x.qtyOutstaning + pendingQty;
                    pendingQty = 0;
                    judgeQty = 0;
                }
                else
                {
                    x.qtyActual = 0;
                    x.qtyOutstaning = x.qtyNeeded;
                    pendingQty = pendingQty - judgeQty;
                    judgeQty = 0;
                }
            }
            luSSEntity.SaveChanges();
            if (pendingQty > 0)
            {
                var requisition2 = from x in luSSEntity.requisitionDetails
                                   from y in luSSEntity.requisitions
                                   //from z in luSSEntity.requisitionStatus
                                   where x.itemCode == itemCode
                                   //where y.statusId == z.statusId
                                   // where z.statusDescription == "Disbursement" 
                                   //where z.statusDescription=="OutStanding"
                                   from w in luSSEntity.disbursements
                                   from a in luSSEntity.retrievalRequisitions
                                   where w.disbursementId == disbursementId
                                   where a.retrievalId == w.RetrivalId
                                   where a.requisitionId == y.requisitionId
                                   where y.statusId == 2006
                                   || y.statusId == 2008
                                   where x.qtyOutstaning == 0
                                   where y.departmentCode == departmentCode
                                   where x.requisitionId == y.requisitionId
                                   select x;
                List<requisitionDetail> rDetails = requisition2.ToList();
                for (int i = rDetails.Count - 1; i >= 0; i--)
                {
                    judgeQty = Convert.ToInt32(rDetails.ElementAt(i).qtyNeeded) - pendingQty;
                    if (judgeQty >= 0)
                    {
                        rDetails.ElementAt(i).qtyActual = judgeQty;
                        rDetails.ElementAt(i).qtyOutstaning = pendingQty;
                        rDetails.ElementAt(i).outstandingField = true;
                        requisition re = rDetails.ElementAt(i).requisition;
                        re.statusId = 2008;
                        pendingQty = 0;
                        luSSEntity.SaveChanges();
                        break;
                    }
                    else
                    {
                        rDetails.ElementAt(i).qtyActual = 0;
                        rDetails.ElementAt(i).qtyOutstaning = rDetails.ElementAt(i).qtyNeeded;
                        rDetails.ElementAt(i).outstandingField = true;
                        requisition re = rDetails.ElementAt(i).requisition;
                        re.statusId = 2008;
                        luSSEntity.SaveChanges();
                        pendingQty = pendingQty - Convert.ToInt32(rDetails.ElementAt(i).qtyNeeded);

                    }
                }
            }
        }//
        public void confirmDisbursementonWeb(List<disbursementDetail> details)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            foreach (disbursementDetail d in details)
            {
                var compareD = from x in luSSEntity.disbursementDetails
                               where x.disbursementId == d.disbursementId
                               where x.itemCode == d.itemCode
                               select x;
                foreach (var x in compareD)
                {
                    if (x.reqQuantity > d.receivedQuantity)
                    {
                        changeDisbursementDetail(d.disbursementId, d.itemCode, Convert.ToInt32(d.receivedQuantity), x.disbursement.departmentCode);
                    }
                }
            }
            confirmDisbursement(details.ElementAt(0).disbursementId);
        }
        public void changeRequsitionStatusAfterDisbursement(string departmentCode, int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var req = from x in luSSEntity.requisitions
                      from y in luSSEntity.requisitionStatus
                      from w in luSSEntity.disbursements
                      from a in luSSEntity.retrievalRequisitions
                      where w.disbursementId == disbursementId
                      where a.retrievalId == w.RetrivalId
                      where a.requisitionId == x.requisitionId
                      where y.statusDescription == "Disbursement"
                      where x.statusId == y.statusId
                      where x.departmentCode == departmentCode
                      select x;
            List<requisition> reqs = req.ToList();
            foreach (requisition r in reqs)
            {
                r.statusId = 2007;
            }
            luSSEntity.SaveChanges();
        }//
        public void confirmDisbursement(int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursement = from x in luSSEntity.disbursements
                               where x.disbursementId == disbursementId
                               select x;
            foreach (var x in disbursement)
            {
                x.status = "1";
            }
            luSSEntity.SaveChanges();
            var disbursementDetail = from x in luSSEntity.disbursementDetails
                                     where x.disbursementId == disbursementId
                                     select x;
            List<disbursementDetail> ddetails = disbursementDetail.ToList();
            foreach (disbursementDetail d in ddetails)
            {
                if (d.marks == true)
                {
                    d.receivedQuantity = d.reqQuantity;
                    d.marks = false;
                }
            }
            luSSEntity.SaveChanges();
        }
        public void changeStockCard(int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursementDetail = from x in luSSEntity.disbursementDetails
                                     from y in luSSEntity.disbursements
                                     where x.disbursementId == disbursementId
                                     where y.status == "1"
                                     where x.disbursementId == y.disbursementId
                                     select x;
            List<disbursementDetail> details = disbursementDetail.ToList();
            foreach (disbursementDetail d in details)
            {
                stockCard newtransaction = new stockCard();
                newtransaction.itemCode = d.itemCode;
                newtransaction.transactionDate = d.disbursement.collectionDate;
                newtransaction.transactionType = "Department Requisition" + " (" + d.disbursement.department.departmentName + ")";
                newtransaction.quantity = d.receivedQuantity;
                newtransaction.balance = d.catelogueItem.quantity;
                luSSEntity.stockCards.Add(newtransaction);

            }
            var disbursement = from z in luSSEntity.disbursements
                               where z.disbursementId == disbursementId
                               select z;
            foreach (var z in disbursement)
            {
                z.status = "2";
            }
            luSSEntity.SaveChanges();
        }
        public List<retrieval> getRetrievalList()
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            return lue.retrievals.Where(x =>
                x.status == "1").ToList();
        }
        public List<department> getCanGenrateDepartment(int rid)
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            List<retrievalDetail> rd = lue.retrievalDetails.Where(x =>
                x.retrievalId == rid).ToList();
            List<department> dp = new List<department>();
            foreach (retrievalDetail result in rd)
            {
                int flag = 0;
                foreach (department d in dp)
                {
                    if (result.departmentId == d.departmentCode)
                    {
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    dp.Add(lue.departments.Where(x =>
                        x.departmentCode == result.departmentId).First());
                }
            }
            List<disbursement> db = lue.disbursements.Where(x =>
                x.RetrivalId == rid).ToList();
            if (db.Count == 0)
            {
                return dp;
            }
            else
            {
                foreach (disbursement d in db)
                {
                    for (int i = 0; i <= dp.Count; i++)
                    {
                        if (d.departmentCode == dp[i].departmentCode)
                        {
                            dp.Remove(dp[i]);
                            break;
                        }
                    }
                      
                }
                return dp;
            }
            
        }
        public List<disbursement> getUnConfirm()
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            return lue.disbursements.Where(x =>
                x.status == "0").ToList();
        }

        public List<disbursement> getByDate(DateTime from, DateTime to)
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            return lue.disbursements.Where(x =>
                x.collectionDate >= from &&
                x.collectionDate <= to).ToList();
        }

        public List<Model.DisbursementView> ViewDisForClerk()
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var list = from d in luSSEntity.departments
                       from ds in luSSEntity.disbursements
                       where d.departmentCode == ds.departmentCode
                       where ds.status == "0"
                       group ds by new { ds.departmentCode, d.departmentName } into d
                       select new Model.DisbursementView
                       {
                           departmentCode = d.Key.departmentCode,
                           departmentName = d.Key.departmentName,
                           totalDisburseIdNo = d.Count()
                       };
            return list.ToList();
        }

        public List<Model.DisbursementView> ViewDisbyDeptForClerk(string deptCode)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var list = from ds in luSSEntity.disbursements
                       from d in luSSEntity.departments
                       from c in luSSEntity.collectionPoints
                       from e in luSSEntity.employees
                       where ds.departmentCode == d.departmentCode
                       where ds.departmentCode == deptCode
                       where ds.status == "0"
                       where ds.collectionId == c.collectionPointId
                       where ds.employeeId == e.employeeId
                       select new Model.DisbursementView
                       {
                           disbursementID = ds.disbursementId,
                           departmentCode = deptCode,
                           departmentName = d.departmentName,
                           employeeName = e.employeeName,
                           collectionDate = (DateTime)ds.collectionDate,
                           collectionPointName = c.collectionPointName
                       };
            return list.ToList();
        }

        public List<Model.DisbursementView> ViewDisWithoutItemForClerk(int disId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var list = from d in luSSEntity.departments
                       from ds in luSSEntity.disbursements
                       from e in luSSEntity.employees
                       from cp in luSSEntity.collectionPoints
                       where cp.collectionPointId == ds.collectionId
                       where ds.departmentCode == d.departmentCode
                       where ds.employeeId == e.employeeId
                       where ds.disbursementId == disId
                       select new Model.DisbursementView
                       {
                           departmentName = d.departmentName,
                           employeeId = ds.employeeId,
                           employeeName = e.employeeName,
                           collectionPointId = ds.collectionId,
                           collectionPointName = cp.collectionPointName,
                           collectionDate = ds.collectionDate
                       };
            return list.ToList();
        }

        //1
        public List<Model.disbursementdetails> getDisbursementDetailsListforMobile(int disbursementId)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var disbursementDetailsForMobile = from x in luSSEntity.disbursementDetails
                                               where x.disbursementId == disbursementId
                                               select x;
            List<disbursementDetail> details = disbursementDetailsForMobile.ToList();
            List<Model.disbursementdetails> detailsforMobile = new List<Model.disbursementdetails>();
            foreach (disbursementDetail d in details)
            {
                string itemName = d.catelogueItem.itemDescription;
                int qty = Convert.ToInt32(d.reqQuantity);
                int recqty = Convert.ToInt32(d.receivedQuantity);
                //CHANGE HERE
                detailsforMobile.Add(new Model.disbursementdetails(itemName, qty, recqty));
            }
            return detailsforMobile;
        }

        public List<int> getDisIds(string dcode)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var ids = from d in luSSEntity.disbursements
                      where d.status == "0"
                      where d.departmentCode == dcode
                      select d.disbursementId;
            return ids.ToList();
        }


        //2
       
        public List<Model.DisbursementView> ViewDisbursementbydept(string deptCode)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            var list = from d in luSSEntity.disbursements
                       from dd in luSSEntity.disbursementDetails
                       from c in luSSEntity.catelogueItems
                       where d.disbursementId == dd.disbursementId
                       where dd.itemCode == c.itemCode
                       where d.departmentCode == deptCode
                       where d.status == "0"
                       //  where dd.marks == false
                       select new Model.DisbursementView
                       {
                           disbursementID = d.disbursementId,
                           itemCode = dd.itemCode,
                           itemDescription = c.itemDescription,
                           reqQuantity = dd.reqQuantity
                       };

            return list.ToList();

        }

        public int getUserid(string username)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            return luSSEntity.employees.Where(e => e.employeeName == username).First().employeeId;
        }

        public string getItemcode(string itemDes)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            return luSSEntity.catelogueItems.Where(ca => ca.itemDescription == itemDes).First().itemCode;
        }
    }
}