using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team8_ADProjectLUStationerySystem;
using Team8_ADProjectLUStationerySystem.DAO;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    logicUniversityEntities logic = new logicUniversityEntities();

    CollectionPointBLL cp = new CollectionPointBLL();
    
    Requisitioin r = new Requisitioin();
    Retrieval rt = new Retrieval();
    Disbursement d = new Disbursement();
    AdjustInventoryBLL ad = new AdjustInventoryBLL();
    OrderBLL o = new OrderBLL();
    EmployeeBLL E = new EmployeeBLL();
    
    ItemBLL i = new ItemBLL();

    public List<int> getAllRetrievalId()
    {
        return rt.getAllRetrievalId();

    }
    public int getCurrentRepID(string code)
    {
        return cp.getCurrentRepID(code);

    }


    public void InsertProduct(WCF_department p)
    {
        //cp.InsertProduct(
        //   new department(p.);
    }

    //public List<WCF_RequisitionView> viewRequistion(string empid)
    //{
    //    Requisitioin r = new Requisitioin();
    //    int empidInt = Convert.ToInt32(empid);
    //    List<LUStationerySystem.Model.RequisitionView> list = r.ViewrequisionbyID(empidInt);
    //    List<WCF_RequisitionView> list1 = new List<WCF_RequisitionView>();
    //    foreach (LUStationerySystem.Model.RequisitionView rv in list)
    //    {
    //        list1.Add(new WCF_RequisitionView(rv.itemDescription, Convert.ToInt32(rv.qtyNeeded), rv.statusDescription));
    //    }
    //    return list1;
    //}

    public WCF_department getOne()
    {
        department i = cp.getOne();

        return new WCF_department(i.departmentCode, i.departmentName, i.contactName, Convert.ToInt32(i.telephoneNo), i.headName, Convert.ToInt32(i.collectionPointId), i.photos, i.FaxNo, Convert.ToInt32(i.RepresentativeID));

    }
    public List<WCF_RetriveViewbyCategory> TotalRetriveByCategory(string retIp)
    {
        List<Team8_ADProjectLUStationerySystem.Model.RetriveViewbyCategory> list = r.TotalRetriveByCategory(Convert.ToInt32(retIp));
        List<WCF_RetriveViewbyCategory> list1 = new List<WCF_RetriveViewbyCategory>();
        foreach (Team8_ADProjectLUStationerySystem.Model.RetriveViewbyCategory i in list)
        {
            list1.Add(new WCF_RetriveViewbyCategory(i.categoryId, i.categoryName, i.actualQuantity));
        }
        return list1;
    }

    public List<WCF_RetriveViewbyDept> RetriveByDept(string categoryId, string retId)
    {

        List<Team8_ADProjectLUStationerySystem.Model.RetriveViewbyDept> list = r.RetriveByDept(Convert.ToInt32(categoryId), Convert.ToInt32(retId));
        List<WCF_RetriveViewbyDept> list1 = new List<WCF_RetriveViewbyDept>();
        foreach (Team8_ADProjectLUStationerySystem.Model.RetriveViewbyDept i in list)
        {
            list1.Add(new WCF_RetriveViewbyDept(i.retrievalId, i.departmentId, i.depetName, i.itemCode, i.itemDescription, i.actualQuantity));
        }
        return list1;
    }
    //public bool ConfirmRetrieval(string RetrievalId)
    //{

    //}
    public List<WCF_department> getAllDepartment()
    {
        List<department> list = cp.getAllDepartment();
        List<WCF_department> list1 = new List<WCF_department>();
        foreach (department i in list)
        {
            list1.Add(new WCF_department(i.departmentCode, i.departmentName, i.contactName, Convert.ToInt32(i.telephoneNo), i.headName, Convert.ToInt32(i.collectionPointId), i.photos, i.FaxNo, Convert.ToInt32(i.RepresentativeID)));
            //String p1, p2, p4,p6,p7 ;
            //int p3,p5,p8;
            //if (i.departmentName == null)
            //{
            //    p1 = "";
            //}
            //else {
            //    p1 = i.departmentName;
            //}
            //if (i.contactName == null)
            //{
            //    p2 = "";
            //}
            //else
            //{
            //    p2 = i.contactName;
            //}
            //if (!i.telephoneNo.HasValue)
            //{
            //    p3 = 0;
            //}
            //else
            //{
            //    p3 = (int)i.telephoneNo;
            //}
            //if (i.headName == null)
            //{
            //    p4 = "";
            //}
            //else
            //{
            //    p4 = i.headName;
            //}
            //if (!i.collectionPointId.HasValue)
            //{
            //    p5= 0;
            //}
            //else
            //{
            //    p5 = (int)i.collectionPointId;
            //}
            //if (i.photos == null)
            //{
            //    p6 = "";
            //}
            //else
            //{
            //    p6 = i.photos;
            //}
            //if (i.faxNo == null)
            //{
            //    p7 = "";
            //}
            //else
            //{
            //    p7 = i.faxNo;
            //}
            //if (!i.representativeID.HasValue)
            //{
            //    p8 = 0;
            //}
            //else
            //{
            //    p8 = (int)i.representativeID;
            //}
            //list1.Add(new WCF_department(i.departmentCode, p1, p2, p3, p4, p5, p6, p7, p8));
        }
        return list1;
    }

    public List<string> getDept()
    {
        return cp.getAllDepartments();
    }

    public List<WCF_DisForClerk> ViewDisForClerk()
    {

        List<Team8_ADProjectLUStationerySystem.Model.DisbursementView> list = d.ViewDisForClerk();
        List<WCF_DisForClerk> list1 = new List<WCF_DisForClerk>();
        foreach (Team8_ADProjectLUStationerySystem.Model.DisbursementView i in list)
        {
            list1.Add(new WCF_DisForClerk(i.departmentCode, i.departmentName, i.totalDisburseIdNo));
        }
        return list1;
    }

    public List<WCF_DisbyDeptForClerk> ViewDisbyDeptForClerk(string deptCode)
    {

        List<Team8_ADProjectLUStationerySystem.Model.DisbursementView> list = d.ViewDisbyDeptForClerk(deptCode);
        List<WCF_DisbyDeptForClerk> list1 = new List<WCF_DisbyDeptForClerk>();
        foreach (Team8_ADProjectLUStationerySystem.Model.DisbursementView i in list)
        {
            DateTime a = (DateTime)i.collectionDate;
            list1.Add(new WCF_DisbyDeptForClerk(i.disbursementID, i.departmentCode, i.departmentName, i.employeeName, a.ToString("dd-MM-yyyy"), i.collectionPointName));
        }
        return list1;
    }

    public List<WCF_DisWithoutItemForClerk> ViewDisWithoutItemForClerk(string disId)
    {
        List<Team8_ADProjectLUStationerySystem.Model.DisbursementView> list = d.ViewDisWithoutItemForClerk(Convert.ToInt32(disId));
        List<WCF_DisWithoutItemForClerk> list1 = new List<WCF_DisWithoutItemForClerk>();
        foreach (Team8_ADProjectLUStationerySystem.Model.DisbursementView i in list)
        {
            list1.Add(new WCF_DisWithoutItemForClerk(i.departmentName, i.employeeId, i.employeeName, i.collectionPointId, i.collectionPointName, i.collectionDate));
        }
        return list1;
    }

    public List<WCF_DisbursementDetailsListforMobile> DisbursementDetailsListforMobile(string disId)
    {
        List<Team8_ADProjectLUStationerySystem.Model.disbursementdetails> list = d.getDisbursementDetailsListforMobile(Convert.ToInt32(disId));
        List<WCF_DisbursementDetailsListforMobile> list1 = new List<WCF_DisbursementDetailsListforMobile>();
        foreach (Team8_ADProjectLUStationerySystem.Model.disbursementdetails i in list)
        {
            list1.Add(new WCF_DisbursementDetailsListforMobile(i.itemDes, i.reqQty, i.receivedQuantity));
        }
        return list1;
    }

    public bool ApproveAdjustment(string aId)
    {
        ad.ApproveAdjustmentt(Convert.ToInt32(aId));
        return true;
    }

    public bool RejectAdjustment(string aId)
    {
        ad.RejectAdjustmentt(Convert.ToInt32(aId));
        return true;
    }

    public bool ChangeStatus(string PoId, string status)
    {
        o.ChangeStatus(Convert.ToInt32(PoId), status);
        return true;
    }

    public bool Confirmretrieval(string rid)
    {
        rt.ComfirmRetriavleList(Convert.ToInt32(rid), 0);
        return true;
    }

    //New Methods
    public bool ChangaePODetails(string PodId, string reqty)
    {
        o.ChangePODetails(Convert.ToInt32(PodId), Convert.ToInt32(reqty));
        return true;
    }

    public int? DefaultReorderQuantity(string itemcode)
    {
        return o.DefaultReorderQuantity(itemcode);
    }

    public int ConfrimPOStatus(string poid)
    {
        return o.ConfrimPOStatus(poid);
    }

    public List<int> getPOIds()
    {
        return o.getPOIds();
    }

    public List<WCF_POdetails> POdetails(string poid)
    {
        List<Team8_ADProjectLUStationerySystem.Model.PoDetails> list = o.podetails(Convert.ToInt32(poid));
        List<WCF_POdetails> list1 = new List<WCF_POdetails>();
        foreach (Team8_ADProjectLUStationerySystem.Model.PoDetails i in list)
        {
            list1.Add(new WCF_POdetails(i.purchaseDetail_Id, i.itemdesp, i.orderedQuantity));
        }
        return list1;
    }

    public bool CreatePO(List<WCF_CreatePO> cp)
    {
        string supplierCode = "";
        int uid = 0;
        List<purchaseDetail> listrd = new List<purchaseDetail>();
        foreach (WCF_CreatePO r in cp)
        {
            supplierCode = r.SupplierCode;
            uid = r.UserId;
            string itemcode = r.ItemCode;
            double? price = i.getPrice(itemcode);
            int? qty = r.OrderedQuantity;
            purchaseDetail rd = new purchaseDetail();
            rd.itemCode = itemcode;
            rd.orderedQuantity = qty;
            rd.price = price;
            rd.amount = price * qty;
            rd.receivedQuantity = qty;
            listrd.Add(rd);
        }

        o.CreateOrder(supplierCode, uid, listrd);
        return true;
    }

    public List<string> getAllClerks()
    {
        return E.getAllClerks();
    }

    public List<int> getDisIds(string dcode)
    {
        return d.getDisIds(dcode);
    }

    public bool confirmDisbursement(string disId, string deptcode)
    {
        d.confirmDisbursementformob(Convert.ToInt32(disId), deptcode);

        return true;
    }

    public int RejectPOStatus(string poid)
    {
        return o.RejectPOStatus(poid);
    }

}
