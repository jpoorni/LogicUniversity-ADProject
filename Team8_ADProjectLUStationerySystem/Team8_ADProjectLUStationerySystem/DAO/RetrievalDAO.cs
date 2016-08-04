using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class RetrievalDAO
    {
        logicUniversityEntities lue = new logicUniversityEntities();

        //generate
        public void generateNew(int i)
        {
            //i = 0 for normal
            //i = 1 for self collection
            if (i == 0)
            {
                retrieval retrieval = new retrieval();
                retrieval.status = "0";//change later
                lue.retrievals.Add(retrieval);
                lue.SaveChanges();

            }
            else if (i == 1)
            {
                retrieval retrieval = new retrieval();
                retrieval.status = "10";//change later
                lue.retrievals.Add(retrieval);
                lue.SaveChanges();
            }


        }
        public void generateScRetrievalList()
        {
            List<requisition> normalRequisitionList = lue.requisitions.Where(x =>
            x.statusId == 2003 &&
            x.selfCollection == true).ToList();

            if (normalRequisitionList.Count != 0)
            {
                foreach (requisition result in normalRequisitionList)
                {
                    
                    List<requisitionDetail> detailList = lue.requisitionDetails.Where(x =>
                        x.requisitionId == result.requisitionId &&
                        x.outstandingField==false &&
                        x.qtyActual!=x.qtyNeeded).ToList();
                    if (detailList.Count != 0)
                    {
                        generateNew(1);
                        List<retrieval> rl = lue.retrievals.Where(x =>
                         x.status == "10").ToList();
                        retrieval last = rl.Last();
                        int rId = last.retrievalId;//get retrieval id

                        foreach (requisitionDetail rd in detailList)
                        {
                            var bin = lue.catelogueItems.Where(x =>
                               x.itemCode == rd.itemCode).First().bin;
                            retrievalDetail record = new retrievalDetail();
                            record.retrievalId = rId;
                            record.itemCode = rd.itemCode;
                            record.departmentId = result.departmentCode;
                            record.needQuantity = rd.qtyNeeded-rd.qtyActual-rd.qtyOutstaning;
                            record.actualQuantity = record.needQuantity;
                            record.bin = bin;
                            record.employeeId = result.employeeId;
                            lue.retrievalDetails.Add(record);
                            rd.qtyActual = rd.qtyNeeded;
                            lue.SaveChanges();
                        }

                        generateSCRRList(result, rId);
                    }
                    

                }
            }
            


            List<requisition> outRequisitionList = lue.requisitions.Where(x =>
            x.statusId == 2009 &&
            x.selfCollection == true).ToList();
            if (outRequisitionList.Count != 0)
            {
                foreach (requisition result in outRequisitionList)
                {
                    int rId = 0;

                    List<requisitionDetail> detailList = lue.requisitionDetails.Where(x =>
                        x.requisitionId == result.requisitionId && 
                        x.outstandingField==true &&
                        x.qtyNeeded!=x.qtyActual+x.qtyOutstaning).ToList();
                    if (detailList.Count != 0)
                    {
                        generateNew(1);
                        List<retrieval> rl = lue.retrievals.Where(x =>
                         x.status == "10").ToList();
                        retrieval last = rl.Last();
                        rId = last.retrievalId;//get retrieval id

                        foreach (requisitionDetail rd in detailList)
                        {
                            if (rd.qtyActual == 0)
                            {
                                var bin = lue.catelogueItems.Where(x =>
                               x.itemCode == rd.itemCode).First().bin;
                                retrievalDetail record = new retrievalDetail();
                                record.retrievalId = rId;
                                record.itemCode = rd.itemCode;
                                record.departmentId = result.departmentCode;
                                record.needQuantity = rd.qtyNeeded - rd.qtyOutstaning;
                                record.actualQuantity = rd.qtyNeeded - rd.qtyOutstaning;
                                record.bin = bin;
                                record.employeeId = result.employeeId;
                                lue.retrievalDetails.Add(record);
                                rd.qtyActual = rd.qtyNeeded - rd.qtyOutstaning;
                                lue.SaveChanges();
                            }
                            else
                            {
                                var bin = lue.catelogueItems.Where(x =>
                               x.itemCode == rd.itemCode).First().bin;
                                retrievalDetail record = new retrievalDetail();
                                record.retrievalId = rId;
                                record.itemCode = rd.itemCode;
                                record.departmentId = result.departmentCode;
                                record.needQuantity = rd.qtyNeeded - rd.qtyActual - rd.qtyOutstaning;
                                record.actualQuantity = rd.qtyNeeded - rd.qtyActual - rd.qtyOutstaning;
                                record.bin = bin;
                                record.employeeId = result.employeeId;
                                lue.retrievalDetails.Add(record);
                                rd.qtyActual = rd.qtyNeeded - rd.qtyOutstaning;
                                lue.SaveChanges();
                            }
                        } generateSCRRList(result, rId);
                    }
                    
                }
           
                
            }

        }
        public void generateSCRRList(requisition result, int rId)
        {
            retrievalRequisition rr = new retrievalRequisition();
            rr.retrievalId = rId;
            rr.requisitionId = result.requisitionId;
            lue.retrievalRequisitions.Add(rr);
            lue.SaveChanges();

        }
        public int generateRetrievalList()
        {
            
            int rId = 0;
            List<requisitionDetail> detailList = new List<requisitionDetail>();
            List<requisitionDetail> outstandingDetail = new List<requisitionDetail>();

            List<requisition> requisitionList = lue.requisitions.Where(x =>
            x.statusId == 2003 &&
            x.selfCollection == false).ToList();
            if (requisitionList.Count != 0)
            {
                foreach (requisition result in requisitionList)
                {
                    int id = result.requisitionId;
                    List<requisitionDetail> rd = lue.requisitionDetails.Where(x => x.requisitionId == id).ToList();
                    detailList.AddRange(rd);
                }

            }
            

            //get outstanding details only
            List<requisition> outstandList = lue.requisitions.Where(x =>
            x.statusId == 2009 &&
            x.selfCollection == false).ToList();
            if (outstandList.Count != 0)
            {
                
                foreach (requisition result in outstandList)
                {
                    int id = result.requisitionId;
                    List<requisitionDetail> rd = lue.requisitionDetails.Where(x => x.requisitionId == id &&
                                                                                   x.outstandingField == true &&
                                                                                   x.qtyNeeded!=x.qtyOutstaning+x.qtyActual).ToList();
                    outstandingDetail.AddRange(rd);

                    List<requisitionDetail> rd2 = lue.requisitionDetails.Where(x => x.requisitionId == id &&
                                                                                   x.outstandingField == false &&
                                                                                   x.qtyNeeded!=x.qtyActual).ToList();
                    detailList.AddRange(rd2);
                }
            }

            if (detailList.Count != 0 || outstandingDetail.Count != 0)
            {
                generateNew(0);

                List<retrieval> rl = lue.retrievals.Where(x =>
                    x.status == "0").ToList();

                retrieval last = rl.Last();
                rId = last.retrievalId;//get retrieval id
                generateRRList(requisitionList, rId);
                generateRRList(outstandList, rId);

               
            }
           
            //List<requisitionDetail> outstandingDetail = lue.requisitionDetails.Where(x =>
            //x.outstandingField == true).ToList();
            if (detailList.Count != 0)
            {
                foreach (requisitionDetail result in detailList)
                {
                    //get department id
                    string did = lue.requisitions.Where(x =>
                    x.requisitionId == result.requisitionId).First().departmentCode;

                    if (result.qtyActual == 0)//for outstanding change to process one. in case the item is already collect.
                    {
                        //find record have or not
                        List<retrievalDetail> recordList = lue.retrievalDetails.Where(x =>
                            x.retrievalId == rId &&
                            x.departmentId == did &&
                            x.itemCode == result.itemCode).ToList();
                        int need = 0;
                        if (result.qtyNeeded.HasValue)
                        {
                            need = result.qtyNeeded.Value;
                        }

                        if (recordList.Count != 0)
                        {
                            retrievalDetail record = recordList.First();
                            record.needQuantity = record.needQuantity + need;
                            record.actualQuantity = record.needQuantity;
                            result.qtyActual = need;
                            lue.SaveChanges();
                        }
                        else
                        {
                            var bin = lue.catelogueItems.Where(x =>
                            x.itemCode == result.itemCode).First().bin;

                            retrievalDetail record = new retrievalDetail();
                            record.retrievalId = rId;
                            record.itemCode = result.itemCode;
                            record.departmentId = did;
                            record.needQuantity = need;
                            record.actualQuantity = record.needQuantity;
                            record.bin = bin;
                            lue.retrievalDetails.Add(record);
                            result.qtyActual = need;
                            lue.SaveChanges();

                        }
                        requisition r = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        //r.statusId = 2004;
                        lue.SaveChanges();
                    }
                    else if (result.qtyActual != 0 && result.qtyActual != result.qtyNeeded && result.qtyOutstaning!=result.qtyNeeded)
                    {
                        List<retrievalDetail> recordList = lue.retrievalDetails.Where(x =>
                            x.retrievalId == rId &&
                            x.departmentId == did &&
                            x.itemCode == result.itemCode).ToList();
                        int need = 0;
                        if (result.qtyNeeded.HasValue && result.qtyActual.HasValue)
                        {
                            need = result.qtyNeeded.Value - result.qtyActual.Value;
                        }


                        if (recordList.Count != 0)
                        {
                            retrievalDetail record = recordList.First();
                            record.needQuantity = record.needQuantity + need;
                            record.actualQuantity = record.needQuantity;
                            result.qtyActual = result.qtyNeeded;
                            lue.SaveChanges();
                        }
                        else
                        {
                            var bin = lue.catelogueItems.Where(x =>
                            x.itemCode == result.itemCode).First().bin;

                            retrievalDetail record = new retrievalDetail();
                            record.retrievalId = rId;
                            record.itemCode = result.itemCode;
                            record.departmentId = did;
                            record.needQuantity = need;
                            record.actualQuantity = record.needQuantity;
                            record.bin = bin;
                            lue.retrievalDetails.Add(record);
                            result.qtyActual = result.qtyNeeded;
                            lue.SaveChanges();

                        }
                        requisition r = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        //r.statusId = 2004;
                        lue.SaveChanges();

                    }

                }
            }

            if (outstandingDetail.Count != 0)
            {
                foreach (requisitionDetail result in outstandingDetail)
                {
                    //get department id
                    string did = lue.requisitions.Where(x =>
                    x.requisitionId == result.requisitionId).First().departmentCode;

                    //find record have or not
                    List<retrievalDetail> recordList = lue.retrievalDetails.Where(x =>
                            x.retrievalId == rId &&
                            x.departmentId == did &&
                            x.itemCode == result.itemCode).ToList();

                    int needQty = 0;
                    needQty = (int)result.qtyNeeded - (int)result.qtyActual - (int)result.qtyOutstaning;

                    var bin = lue.catelogueItems.Where(x =>
                        x.itemCode == result.itemCode).First().bin;

                    if (recordList.Count != 0)
                    {
                        retrievalDetail record = recordList.First();
                        record.needQuantity=record.needQuantity+needQty;
                        record.actualQuantity=record.needQuantity;
                        result.qtyActual=result.qtyActual+needQty;
                        //result.qtyOutstaning = result.qtyOutstaning - needQty;
                        lue.SaveChanges();

                    }
                    else
                    {
                        

                        retrievalDetail record = new retrievalDetail();
                        record.retrievalId = rId;
                        record.itemCode = result.itemCode;
                        record.departmentId = did;
                        record.needQuantity = needQty;
                        record.actualQuantity = record.needQuantity;
                        record.bin = bin;
                        lue.retrievalDetails.Add(record);
                        //requisitionDetail rd= lue.requisitionDetails.Where(x =>
                        //    x.itemCode == result.itemCode &&
                        //    x.requisitionId == result.requisitionId).First();
                        //rd.qtyActual = rd.qtyActual + needQty;
                        //result.qtyOutstaning = result.qtyOutstaning - needQty;
                        result.qtyActual = result.qtyActual+needQty; 
                        lue.SaveChanges();
                        

                    }

                } 
            }
            
            return rId;
        }
        public void generateRRList(List<requisition> ld, int retrievalId)
        {
            foreach (requisition result in ld)
            {
                retrievalRequisition rr = new retrievalRequisition();
                rr.retrievalId = retrievalId;
                rr.requisitionId = result.requisitionId;
                lue.retrievalRequisitions.Add(rr);
                lue.SaveChanges();
            }
        }

        //process
        public void processOutstandSelfcollectionRequisition(List<int> idList)
        {
            List<requisition> AllList = new List<requisition>();
            foreach (int i in idList)
            {
                requisition r = lue.requisitions.Where(x =>
                    x.requisitionId == i).First();
                AllList.Add(r);
            }
            List<catelogueItem> itemList = lue.catelogueItems.ToList();

            List<requisition> outstandingList = AllList.Where(x =>
            x.statusId == 2008 &&
            x.selfCollection == true).ToList();

            List<requisitionDetail> outstandingDetail = new List<requisitionDetail>();
            foreach (requisition result in outstandingList)
            {
                int id = result.requisitionId;
                outstandingDetail.AddRange(lue.requisitionDetails.Where(x => x.requisitionId == id &&
                                                                             x.outstandingField == true).ToList());
            }


            //outstanding item change.
            foreach (requisitionDetail result in outstandingDetail)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].itemCode == result.itemCode)
                    {
                        if (itemList[i].quantity >= result.qtyOutstaning)
                        {
                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = item.quantity - result.qtyOutstaning;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyActual + result.qtyOutstaning;
                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = 0;
                            updateDetails.outstandingField = false;
                            lue.SaveChanges();

                        }
                        else
                        {
                            //calculate outstanding qty

                            if (result.qtyOutstaning.HasValue && itemList[i].quantity.HasValue)
                            {
                                result.qtyOutstaning = result.qtyOutstaning.Value - itemList[i].quantity.Value;
                            }

                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = 0;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded - result.qtyOutstaning;
                            //result.qtyOutstaning = outstanding;

                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = result.qtyOutstaning;
                            //updateDetails.outstandingField = true;
                            lue.SaveChanges();


                        }

                        break;
                    }
                }



            }

        }
        public void processNormalSelfcollectionRequisition(List<int> idList)
        {
            List<requisition> AllList = new List<requisition>();
            foreach (int i in idList)
            {
                requisition r = lue.requisitions.Where(x =>
                    x.requisitionId == i).First();
                AllList.Add(r);
            }

            List<catelogueItem> itemList = lue.catelogueItems.ToList();

            List<requisition> requisitionList = AllList.Where(x =>
             x.statusId == 2001 &&
             x.selfCollection == true).ToList();

            List<requisitionDetail> detailList = new List<requisitionDetail>();
            foreach (requisition result in requisitionList)
            {
                int id = result.requisitionId;
                detailList.AddRange(lue.requisitionDetails.Where(x => x.requisitionId == id).ToList());
            }

            //change approve requistion
            foreach (requisitionDetail result in detailList)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].itemCode == result.itemCode)
                    {
                        if (itemList[i].quantity >= result.qtyNeeded)
                        {
                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = item.quantity - result.qtyNeeded;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded;
                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            lue.SaveChanges();

                        }
                        else
                        {
                            //calculate outstanding qty
                            int outstanding = 0;
                            if (result.qtyNeeded.HasValue && itemList[i].quantity.HasValue)
                            {
                                outstanding = result.qtyNeeded.Value - itemList[i].quantity.Value;
                            }

                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = 0;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded - outstanding;
                            result.qtyOutstaning = outstanding;

                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = result.qtyOutstaning;
                            updateDetails.outstandingField = true;
                            lue.SaveChanges();

                        }

                        break;
                    }
                }
            }

        }
        public void processNormalRequisition(List<int> idList)
        {
            List<requisition> AllList = new List<requisition>();
            foreach (int i in idList)
            {
                requisition r = lue.requisitions.Where(x =>
                    x.requisitionId == i).First();
                AllList.Add(r);
            }

            List<catelogueItem> itemList = lue.catelogueItems.ToList();

            List<requisition> requisitionList = AllList.Where(x =>
             x.statusId == 2001 &&
             x.selfCollection == false).ToList();

            List<requisitionDetail> detailList = new List<requisitionDetail>();
            foreach (requisition result in requisitionList)
            {
                int id = result.requisitionId;
                detailList.AddRange(lue.requisitionDetails.Where(x => x.requisitionId == id).ToList());
            }

            //change approve requistion
            foreach (requisitionDetail result in detailList)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].itemCode == result.itemCode)
                    {
                        if (itemList[i].quantity >= result.qtyNeeded)
                        {
                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = item.quantity - result.qtyNeeded;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded;
                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            lue.SaveChanges();

                        }
                        else
                        {
                            //calculate outstanding qty
                            int outstanding = (int)result.qtyNeeded - (int)itemList[i].quantity;

                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = 0;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded - outstanding;
                            result.qtyOutstaning = outstanding;

                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = result.qtyOutstaning;
                            updateDetails.outstandingField = true;
                            lue.SaveChanges();

                        }

                        break;
                    }
                }
            }
        }
        public void processOutstandingRequisition(List<int> idList)
        {
            List<requisition> AllList = new List<requisition>();
            foreach (int i in idList)
            {
                requisition r = lue.requisitions.Where(x =>
                    x.requisitionId == i).First();
                AllList.Add(r);
            }
            List<catelogueItem> itemList = lue.catelogueItems.ToList();

            List<requisition> outstandingList = AllList.Where(x =>
            x.statusId == 2008 &&
            x.selfCollection == false).ToList();

            List<requisitionDetail> outstandingDetail = new List<requisitionDetail>();
            foreach (requisition result in outstandingList)
            {
                int id = result.requisitionId;
                outstandingDetail.AddRange(lue.requisitionDetails.Where(x => x.requisitionId == id &&
                                                                             x.outstandingField == true).ToList());
            }


            //outstanding item change.
            foreach (requisitionDetail result in outstandingDetail)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].itemCode == result.itemCode)
                    {
                        if (itemList[i].quantity >= result.qtyOutstaning)
                        {
                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = item.quantity - result.qtyOutstaning;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyActual + result.qtyOutstaning;
                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = 0;
                            updateDetails.outstandingField = false;
                            lue.SaveChanges();

                        }
                        else
                        {
                            //calculate outstanding qty

                            if (result.qtyOutstaning.HasValue && itemList[i].quantity.HasValue)
                            {
                                result.qtyOutstaning = result.qtyOutstaning.Value - itemList[i].quantity.Value;
                            }

                            //change item entity list
                            catelogueItem item = itemList[i];
                            item.quantity = 0;
                            itemList[i] = item;

                            //update requisition detail
                            //result.qtyActual = result.qtyNeeded - result.qtyOutstaning;
                            //result.qtyOutstaning = outstanding;

                            requisitionDetail updateDetails = lue.requisitionDetails.Where(x =>
                            x.requisitionId == result.requisitionId &&
                            x.itemCode == result.itemCode).First();
                            //updateDetails.qtyActual = result.qtyActual;
                            updateDetails.qtyOutstaning = result.qtyOutstaning;
                            //updateDetails.outstandingField = true;
                            lue.SaveChanges();


                        }

                        break;
                    }
                }



            }

        }



        public List<requisition> changeStatus(List<int> idList,int i)
        {
            //logicUniversityEntities lue = new logicUniversityEntities();
            //i = 0, process
            //i = 1, retrieval
            //i = 2, comfirm retrieval
            List<catelogueItem> itemList = lue.catelogueItems.ToList();

            if (i == 0)
            {
                List<requisition> AllList = new List<requisition>();
                foreach (int ii in idList)
                {
                    requisition ir = lue.requisitions.Where(x =>
                        x.requisitionId == ii).First();
                    AllList.Add(ir);
                }
                List<requisition> requisitionList = AllList.Where(x =>
                 x.statusId == 2001 ||
                 x.statusId == 2008).ToList();
                List<requisition> r = new List<requisition>();
                //change status
                foreach (requisition result in requisitionList)
                {
                    int flag = 0;

                    List<requisitionDetail> detailList = lue.requisitionDetails.Where(x =>
                    x.requisitionId == result.requisitionId).ToList();

                    foreach (requisitionDetail details in detailList)
                    {
                        if (details.outstandingField == true)
                            flag = 1;
                    }
                    if (flag == 1)
                    {

                        var updateRequisition = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        updateRequisition.statusId = 2009;
                        lue.SaveChanges();
                        r.Add(updateRequisition);


                    }
                    else
                    {
                        var updateRequisition = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        updateRequisition.statusId = 2003;
                        lue.SaveChanges();
                        r.Add(updateRequisition);

                    }


                } return r;
            }
            else if (i == 1)
            {
                List<requisition> requisitionList = lue.requisitions.Where(x =>
                 x.statusId == 2003).ToList();


                //change status
                foreach (requisition result in requisitionList)
                {
                    int flag = 0;

                    List<requisitionDetail> detailList = lue.requisitionDetails.Where(x =>
                    x.requisitionId == result.requisitionId).ToList();

                    foreach (requisitionDetail details in detailList)
                    {
                        if (details.qtyActual != details.qtyNeeded)
                            flag = 1;
                    }
                    if (flag != 1)
                    {

                        var updateRequisition = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        updateRequisition.statusId = 2004;
                        lue.SaveChanges();

                    }

                    

                    

                }
                List<requisition> requisitionList2 = lue.requisitions.Where(x =>
                 x.statusId == 2009).ToList();
                //change status
                foreach (requisition r in requisitionList2)
                {
                    r.statusId = 2008;
                    lue.SaveChanges();

                }

                return null;
            }
            else if (i == 2)
            {
                List<requisition> requisitionList = lue.requisitions.Where(x =>
                 x.statusId == 2004).ToList();
                List<requisition> r = new List<requisition>();

                //change status
                foreach (requisition result in requisitionList)
                {
                    int flag = 0;

                    List<requisitionDetail> detailList = lue.requisitionDetails.Where(x =>
                    x.requisitionId == result.requisitionId).ToList();

                    foreach (requisitionDetail details in detailList)
                    {
                        if (details.qtyActual != details.qtyNeeded)
                            flag = 1;
                    }
                    if (flag == 1)
                    {

                        var updateRequisition = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        updateRequisition.statusId = 2008;
                        lue.SaveChanges();
                        r.Add(updateRequisition);

                    }
                    else
                    {
                        var updateRequisition = lue.requisitions.Where(x =>
                        x.requisitionId == result.requisitionId).First();
                        updateRequisition.statusId = 2005;
                        lue.SaveChanges();
                    }

                }

                return r;

            }
            return null;
        }





        public void comfirmRetrievalDetails(retrievalDetail result)
        {
            retrievalDetail record = lue.retrievalDetails.Where(x =>
                   x.retrievalId == result.retrievalId &&
                   x.itemCode == result.itemCode &&
                   x.departmentId == result.departmentId).First();
            List<requisition> all=new List<requisition>();

            List<retrievalRequisition> RR = lue.retrievalRequisitions.Where(x=>
                x.retrievalId==record.retrievalId).ToList();

            foreach(retrievalRequisition rr in RR){
                List<requisition> rd = lue.requisitions.Where(x=>
                    x.requisitionId==rr.requisitionId).ToList();
                all.AddRange(rd);
            }


            if (result.actualQuantity != record.actualQuantity)
            {
                int miss = 0;
                miss = (int)record.actualQuantity - (int)result.actualQuantity;

                List<requisition> rqs = all.Where(x =>
                    x.departmentCode == result.departmentId).ToList();
                List<requisitionDetail> rdt = new List<requisitionDetail>();
                foreach (requisition rqss in rqs)
                {
                    rdt.AddRange(lue.requisitionDetails.Where(x =>
                        x.requisitionId == rqss.requisitionId &&
                        x.itemCode == result.itemCode &&
                        x.outstandingField == true).ToList());
                }


                if (rdt.Count != 0)
                {
                    requisitionDetail rd = rdt.First();
                    if (rd.qtyOutstaning + miss <= rd.qtyNeeded)
                    {
                        rd.qtyOutstaning = rd.qtyOutstaning + miss;
                        rd.qtyActual = rd.qtyActual - miss;
                        record.actualQuantity = result.actualQuantity;
                        lue.SaveChanges();//right
                    }
                    else
                    {
                        int last = 0;
                        last = (int)rd.qtyOutstaning + miss - (int)rd.qtyNeeded;
                        rd.qtyOutstaning = rd.qtyNeeded;
                        rd.qtyActual = 0;
                        record.actualQuantity = result.actualQuantity;
                        lue.SaveChanges();

                        
                        List<requisitionDetail> list = new List<requisitionDetail>();
                        foreach (requisition rqss in rqs)
                        {
                            list.AddRange(lue.requisitionDetails.Where(x =>
                                x.requisitionId == rqss.requisitionId &&
                                x.itemCode == result.itemCode &&
                                x.outstandingField == false).ToList());
                        }
                       
                        int flag = 0;
                        while (flag == 0 /*&& last != 0*/)
                        {
                            requisitionDetail rst = list.Last();
                            if (rst.qtyNeeded >= last)
                            {
                                requisition t = lue.requisitions.Where(x =>
                                x.requisitionId == rst.requisitionId).First();
                                requisitionDetail td = lue.requisitionDetails.Where(x =>
                                x.requisitionId == rst.requisitionId &&
                                x.itemCode == rst.itemCode).First();
                                t.statusId = 2008;
                                td.qtyActual = td.qtyActual - last;
                                td.qtyOutstaning = last;
                                td.outstandingField = true;

                                lue.SaveChanges();
                                flag = 1;
                            }
                            else
                            {
                                last = last - (int)rst.qtyNeeded;
                                requisition t = lue.requisitions.Where(x =>
                                x.requisitionId == rst.requisitionId).First();
                                requisitionDetail td = lue.requisitionDetails.Where(x =>
                                x.requisitionId == rst.requisitionId &&
                                x.itemCode == rst.itemCode).First();
                                t.statusId = 2008;
                                td.qtyActual = 0;
                                td.qtyOutstaning = td.qtyNeeded;
                                td.outstandingField = true;
                                lue.SaveChanges();

                                list.Remove(list.Last());
                            }
                        }
                    }
                }//right
                else
                {
                    List<requisitionDetail> list = new List<requisitionDetail>();
                    foreach (requisition rqss in rqs)
                    {
                        list.AddRange(lue.requisitionDetails.Where(x =>
                            x.requisitionId == rqss.requisitionId &&
                            x.itemCode == result.itemCode &&
                            x.outstandingField == false).ToList());
                    }

                    int flag = 0;
                    while (flag == 0 /*&& last != 0*/)
                    {
                        requisitionDetail rst = list.Last();
                        if (rst.qtyNeeded >= miss)
                        {
                            requisition t = lue.requisitions.Where(x =>
                            x.requisitionId == rst.requisitionId).First();
                            requisitionDetail td = lue.requisitionDetails.Where(x =>
                            x.requisitionId == rst.requisitionId &&
                            x.itemCode == rst.itemCode).First();
                            t.statusId = 2008;
                            td.qtyActual = td.qtyActual - miss;
                            td.qtyOutstaning = miss;
                            td.outstandingField = true;
                            //rst.qtyActual = miss;
                            lue.SaveChanges();
                            flag = 1;
                        }
                        else
                        {
                            miss = miss - (int)rst.qtyNeeded;
                            requisition t = lue.requisitions.Where(x =>
                            x.requisitionId == rst.requisitionId).First();
                            requisitionDetail td = lue.requisitionDetails.Where(x =>
                                x.requisitionId == rst.requisitionId &&
                                x.itemCode == rst.itemCode).First();
                            t.statusId = 2008;
                            td.qtyActual = 0;
                            td.qtyOutstaning = td.qtyNeeded;
                            td.outstandingField = true;
                            lue.SaveChanges();
                            list.Remove(list.Last());
                        }
                    }
                }
            }

            retrievalDetail rtvd = lue.retrievalDetails.Where(x =>
                x.retrievalId == result.retrievalId &&
                x.itemCode == result.itemCode &&
                x.departmentId == result.departmentId).First();
            rtvd.actualQuantity = result.actualQuantity;
            lue.SaveChanges();
        }
        public void comfirmRetrievalList(int rid, int i)
        {
            //change retrieval status
            //i == 0 normal
            //i == 1 selfcollection
            if (i == 0)
            {
                retrieval j = lue.retrievals.Where(x =>
            x.retrievalId == rid).First();
                j.status = "1";
                lue.SaveChanges();
            }
            else if (i == 1)
            {
                retrieval j = lue.retrievals.Where(x =>
            x.retrievalId == rid).First();
                j.status = "11";//11 means close.
                lue.SaveChanges();
                changeStockCard(rid);
            }

        }
        public void changeStockCard(int rid)
        {
            retrieval rtl = lue.retrievals.Where(x =>
                x.retrievalId == rid).First();
            List<retrievalDetail> rd = lue.retrievalDetails.Where(x =>
                x.retrievalId == rid).ToList();
            foreach (retrievalDetail r in rd)
            {
                stockCard newtransaction = new stockCard();
                newtransaction.itemCode = r.itemCode;
                newtransaction.transactionDate = DateTime.Now;
                newtransaction.transactionType = "Department Requisition" + " (" + r.department.departmentName + ")";
                newtransaction.quantity = r.actualQuantity;
                newtransaction.balance = r.catelogueItem.quantity;
                lue.stockCards.Add(newtransaction);

            }
            lue.SaveChanges();
        }
        public List<requisition> getApproveRequisition()
        {
            return lue.requisitions.Where(x =>
                x.statusId == 2001 ||
                x.statusId == 2008).ToList();

        }
        
        public List<retrievalDetail> getOneRetrieval(int rid)
        {
            return lue.retrievalDetails.Where(x =>
                x.retrievalId == rid).ToList();

        }

        public List<requisition> getForPorcess()
        {
            return lue.requisitions.Where(x =>
                x.statusId == 2001 ||
                x.statusId == 2008).ToList();
        }

        public List<requisitionDetail> getDetails(int id)
        {
            return lue.requisitionDetails.Where(x =>
                x.requisitionId == id).ToList();
        }

        public List<requisitionDetail> getOutstandingDetail(List<int>idList)
        {
            List<requisitionDetail> outstand = new List<requisitionDetail>();
            foreach (int id in idList)
            {
                outstand.AddRange(lue.requisitionDetails.Where(x =>
                    x.requisitionId == id &&
                    x.outstandingField == true).ToList());
            }
            return outstand;

        }



        public List<retrieval> getNormalView()
        {
            
            return lue.retrievals.ToList();
        }
        public List<retrieval> getUnConfirm()
        {

            return lue.retrievals.Where(x =>
                x.status == "0" ||
                x.status == "10").ToList();
        }



        public string getStatus(int id)
        {
            return lue.retrievals.Where(x =>
                x.retrievalId == id).First().status;
        }

        public List<retrievalDetail> getHistory(string itemCode, string depCode)
        {
            if (itemCode == "0" && depCode == "0")
            {
                return lue.retrievalDetails.ToList();
            }
            else if (itemCode != "0" && depCode == "0")
            {
                return lue.retrievalDetails.Where(x =>
                    x.itemCode == itemCode).ToList();
            }
            else if (itemCode != "0" && depCode != "0")
            {
                return lue.retrievalDetails.Where(x =>
                    x.itemCode == itemCode &&
                    x.departmentId == depCode).ToList();
            }
            else
            {
                return lue.retrievalDetails.Where(x =>
                    x.departmentId == depCode).ToList();
            }
        }

        public List<int> getAllRetrievalId()
        {
            var list = from r in lue.retrievals
                       where r.status == "0"
                       select r.retrievalId;
            return list.ToList();
        }


    }
}