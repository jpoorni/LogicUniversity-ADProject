using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team8_ADProjectLUStationerySystem;
using Team8_ADProjectLUStationerySystem.DAO;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Requisition" in code, svc and config file together.
public class Requisition : IRequisition
{
    logicUniversityEntities logic = new logicUniversityEntities();

    UserBLL user = new UserBLL();
    Retrieval retBLL = new Retrieval();
    AdjustInventoryBLL ABLL = new AdjustInventoryBLL();
    Disbursement db = new Disbursement();

    public List<WCF_RequisitionViewDetails> Requisitiondetails(string reqID)
    {
        Requisitioin r = new Requisitioin();


        int empidInt = Convert.ToInt32(reqID);
        List<Team8_ADProjectLUStationerySystem.Model.Requisitiondetails> list = r.ViewrequisionbyID(empidInt);
        List<WCF_RequisitionViewDetails> list1 = new List<WCF_RequisitionViewDetails>();
        foreach (Team8_ADProjectLUStationerySystem.Model.Requisitiondetails rv in list)
        {
            list1.Add(new WCF_RequisitionViewDetails(rv.itemDescription, Convert.ToInt32(rv.qtyNeeded), Convert.ToInt32(rv.qtyAcutal), rv.statusDescription));
        }
        return list1;
    }

    public List<WCF_RequisitionView> Requistionlist(string empid)
    {
        Requisitioin r = new Requisitioin();
        int empidInt = Convert.ToInt32(empid);
        List<Team8_ADProjectLUStationerySystem.Model.RequisitionView> list = r.Requisitionlist(empidInt);
        List<WCF_RequisitionView> list1 = new List<WCF_RequisitionView>();
        foreach (Team8_ADProjectLUStationerySystem.Model.RequisitionView rv in list)
        {
            DateTime a = (DateTime)rv.requisitionDate;
            list1.Add(new WCF_RequisitionView(rv.requisitionId, a.Date.ToString("dd-MM-yyyy"), rv.totalQty));
        }
        return list1;
    }

    public List<WCF_Viewdisbursement> Viewdisbursement(string deptID)
    {
        Disbursement D = new Disbursement();

        List<Team8_ADProjectLUStationerySystem.Model.DisbursementView> list = D.ViewDisbursementbydept(deptID);
        List<WCF_Viewdisbursement> list1 = new List<WCF_Viewdisbursement>();
        foreach (Team8_ADProjectLUStationerySystem.Model.DisbursementView ds in list)
        {
            list1.Add(new WCF_Viewdisbursement(ds.disbursementID, ds.itemCode, ds.itemDescription, ds.reqQuantity));
        }
        return list1;
    }

    //DeptHead

    public List<WCF_Viewemployee> Viewemployee(string deptID)
    {
        Requisitioin r = new Requisitioin();
        List<Team8_ADProjectLUStationerySystem.Model.RequisitionView> list = r.Reqisitionview(deptID);
        List<WCF_Viewemployee> list1 = new List<WCF_Viewemployee>();
        foreach (Team8_ADProjectLUStationerySystem.Model.RequisitionView ds in list)
        {
            DateTime a = (DateTime)ds.requisitionDate;
            list1.Add(new WCF_Viewemployee(ds.requisitionId, ds.employeeID, ds.employeeName, a.Date.ToString("dd-MM-yyyy"), ds.statusDescription));
        }
        return list1;
    }

    public List<WCF_Viewemployee> Viewrequisitionbydept(string deptID)
    {
        Requisitioin r = new Requisitioin();
        List<Team8_ADProjectLUStationerySystem.Model.RequisitionView> list = r.Viewreqbydept(deptID);
        List<WCF_Viewemployee> list1 = new List<WCF_Viewemployee>();
        foreach (Team8_ADProjectLUStationerySystem.Model.RequisitionView ds in list)
        {
            DateTime a = (DateTime)ds.requisitionDate;
            list1.Add(new WCF_Viewemployee(ds.requisitionId, ds.employeeID, ds.employeeName, a.Date.ToString("dd-MM-yyyy"), ds.statusDescription));
        }
        return list1;
    }

    public List<WCF_empreqlist> Employeereq(string reqid)
    {
        Requisitioin r = new Requisitioin();
        int reqidInt = Convert.ToInt32(reqid);
        List<Team8_ADProjectLUStationerySystem.Model.Requisitiondetails> list = r.Viewrequisition(reqidInt);
        List<WCF_empreqlist> list1 = new List<WCF_empreqlist>();
        foreach (Team8_ADProjectLUStationerySystem.Model.Requisitiondetails rv in list)
        {
            list1.Add(new WCF_empreqlist(rv.category, rv.itemDescription, rv.qtyNeeded));
        }
        return list1;
    }

    //Employee
    public List<WCF_Employee> employeeList(string Dcode)
    {
        EmployeeBLL E = new EmployeeBLL();
       // Employee E = new Employee();
        List<employee> list = E.getAllEmployeesformobile(Dcode);
        List<WCF_Employee> list1 = new List<WCF_Employee>();

        foreach (employee ca in list)
        {
            list1.Add(new WCF_Employee(ca.employeeId, ca.employeeName, ca.departmentCode, ca.phoneNumber, ca.email, ca.status, ca.photo));
        }

        return list1;
    }

    public WCF_Employee getEmployee(string empid)
    {
        EmployeeBLL E = new EmployeeBLL();
       // Employee E = new Employee();
        int empidInt = Convert.ToInt32(empid);
        employee emp = E.getEmployee(empidInt);
        return new WCF_Employee(emp.employeeId, emp.employeeName, emp.departmentCode, emp.phoneNumber, emp.email, emp.status, emp.photo);
    }

    //Deletegate
    public WCF_CurrentDelegate getDelegate(string deptcode)
    {
        //        public int delegationId;
        //public int? employeeId;
        //public string employeeName;
        //public string fromDate;
        //public string toDate;
        //public string reason;
        //public string status;
        EmployeeBLL E = new EmployeeBLL();
       // Employee E = new Employee();
        Team8_ADProjectLUStationerySystem.Model.DelegateEmployee d = E.currentDelegate(deptcode);
        int p1;
        string p2, p3;
        //if(d==null)
        //{
        //    return new WCF_CurrentDelegate(0,"","");
        //}
        //else
        //{
        //    p1 = (int)d.employeeId;
        //    p2 = d.employeeName;
        //    p3 = d.status;
        //    return new WCF_CurrentDelegate(p1, p2, p3);
        //}
        if ((int)d.employeeId == null)
        {
            p1 = 0;
        }
        else
        {
            p1 = (int)d.employeeId;
        }
        if (d.employeeName == null)
        {
            p2 = "";
        }
        else
        {
            p2 = d.employeeName;
        }
        if (d.status == null)
        {
            p3 = "";
        }
        else
        {
            p3 = d.status;
        }

        return new WCF_CurrentDelegate(p1, p2, p3);
    }

    //Collectionpoint
    public WCF_Collectionpoint getCollectionbydept(string deptcode)
    {
        CollectionPointBLL cp = new CollectionPointBLL();
       // CollectionPoint cp = new CollectionPoint();
        collectionPoint cnp = cp.getCollection(deptcode);
        return new WCF_Collectionpoint(cnp.collectionPointId, cnp.collectionPointName, cnp.collectionPointDescription, cnp.latitude, cnp.longtitude, cnp.collectionTime);
    }

    public WCF_Collectionpoint getCollectionbyid(string cid)
    {
        CollectionPointBLL cp = new CollectionPointBLL();
        // CollectionPoint cp = new CollectionPoint();
        int cidInt = Convert.ToInt32(cid);
        collectionPoint cnp = cp.getCollectionid(cidInt);
        return new WCF_Collectionpoint(cnp.collectionPointId, cnp.collectionPointName, cnp.collectionPointDescription, cnp.latitude, cnp.longtitude, cnp.collectionTime);
    }

    //Login
    public WCF_Login Login(string uname, string pwd)
    {
        LoginBLL LL = new LoginBLL();
        Team8_ADProjectLUStationerySystem.Model.Login l = LL.loginformobile(uname, pwd);
        return new WCF_Login(l.username, l.password, l.userId, l.roleId, l.roleDescription, l.departmentCode, l.departmentName);

    }

    //Category
    public List<WCF_itemList> getallitems()
    {
        CategoryBLL C = new CategoryBLL();
       // Category C = new Category();
        List<catelogueItem> list = C.getAllItem();
        List<WCF_itemList> list1 = new List<WCF_itemList>();

        foreach (catelogueItem ca in list)
        {
            list1.Add(new WCF_itemList(ca.itemCode, ca.categoryId, ca.itemDescription, ca.reorderLevel, ca.reorderQuantity, ca.uom, ca.tenderPrice, ca.bin, ca.quantity, ca.photos));
        }

        return list1;
    }

    public List<WCF_itemList> getItemsByCategory(string cName)
    {
        CategoryBLL C = new CategoryBLL();
       // Category C = new Category();
        List<catelogueItem> list = C.getAllItembycategory(cName);
        List<WCF_itemList> list1 = new List<WCF_itemList>();

        foreach (catelogueItem ca in list)
        {
            list1.Add(new WCF_itemList(ca.itemCode, ca.categoryId, ca.itemDescription, ca.reorderLevel, ca.reorderQuantity, ca.uom, ca.tenderPrice, ca.bin, ca.quantity, ca.photos));
        }

        return list1;
    }

    //Adjustment

    public List<WCF_Adjustment> adjustmentList(string id)
    {
        AdjustInventoryBLL A = new AdjustInventoryBLL();
        List<adjustment> list = A.LoadAllAdjust(id);
        List<WCF_Adjustment> list1 = new List<WCF_Adjustment>();

        foreach (adjustment ad in list)
        {
            DateTime a = (DateTime)ad.adjustDate;
            list1.Add(new WCF_Adjustment(ad.adjustmentId, ad.totalAmount, ad.status, ad.authorizedPerson, ad.employeeId, a.Date.ToString("dd-MM-yyyy")));
        }
        return list1;
    }

    public List<WCF_AdjustmentDetails> adjustmentDetails(string id)
    {
        AdjustInventoryBLL A = new AdjustInventoryBLL();
        List<adjustmentDetail> list = A.getAdjustmentDetailsbyID(id);
        List<WCF_AdjustmentDetails> list1 = new List<WCF_AdjustmentDetails>();
        foreach (adjustmentDetail ad in list)
        {
            list1.Add(new WCF_AdjustmentDetails(ad.adjustmentDetailsId, ad.adjustmentId, ad.itemCode, ad.adjustmentQuantity, ad.adjustmentAmount, ad.type, ad.reason));
        }
        return list1;
    }

    //Purchase Order

    public List<WCF_Purcahseorder> purchaseorderlist(string id)
    {
        OrderBLL order = new OrderBLL();
        int pidInt = Convert.ToInt32(id);
        List<WCF_Purcahseorder> list1 = new List<WCF_Purcahseorder>();
        List<purchaseOrder> list = order.GetPurchaseOrderListByUserId(pidInt);
        foreach (purchaseOrder po in list)
        {
            DateTime a = (DateTime)po.purchaseDate;
            list1.Add(new WCF_Purcahseorder(po.purchaseorderno, po.supplierCode, a.Date.ToString("dd-MM-yyyy"), po.status, po.userId, po.totalAmount));
        }
        return list1;
    }

    public List<WCF_Purcahseorderdetails> purchaseorderdetails(string id)
    {
        OrderBLL order = new OrderBLL();
        int poidInt = Convert.ToInt32(id);
        List<WCF_Purcahseorderdetails> list1 = new List<WCF_Purcahseorderdetails>();
        List<purchaseDetail> list = order.GetPurchaseDetailByOrderId(poidInt);
        foreach (purchaseDetail po in list)
        {
            list1.Add(new WCF_Purcahseorderdetails(po.purchaseDetail_Id, po.purchaseOrderno, po.itemCode, po.orderedQuantity, po.price, po.amount, po.receivedQuantity));
        }
        return list1;
    }

    public List<WCF_Supplier> getallsupplier()
    {
        SupplierBLL s = new SupplierBLL();
        List<WCF_Supplier> list1 = new List<WCF_Supplier>();
        List<supplier> list = s.getAllSupplier();
        foreach (supplier sp in list)
        {
            list1.Add(new WCF_Supplier(sp.supplierCode, sp.gstRegistrationNumber, sp.supplierName, sp.contactName, sp.phoneNo, sp.faxNo, sp.address, sp.supplierRank));
        }
        return list1;
    }

    public WCF_Supplier getonesupplier(string id)
    {
        SupplierBLL s = new SupplierBLL();
        supplier sp = s.getSupplierByPK(id);
        return new WCF_Supplier(sp.supplierCode, sp.gstRegistrationNumber, sp.supplierName, sp.contactName, sp.phoneNo, sp.faxNo, sp.address, sp.supplierRank);
    }

    //Post Method

    public int ApproveRequisition(WCF_Viewemployee V)
    {
        Requisitioin r = new Requisitioin();

        Team8_ADProjectLUStationerySystem.Model.RequisitionView RV = new Team8_ADProjectLUStationerySystem.Model.RequisitionView();

        RV.requisitionId = V.requisitionId;

        int rid = (int)RV.requisitionId;

        int statusId = Int32.Parse(V.statusDescription);


        r.changeStatus(rid, statusId);

        return statusId;

    }

    public int RejectRequisition(WCF_Viewemployee V)
    {
        Requisitioin r = new Requisitioin();

        Team8_ADProjectLUStationerySystem.Model.RequisitionView RV = new Team8_ADProjectLUStationerySystem.Model.RequisitionView();

        RV.requisitionId = V.requisitionId;

        int rid = (int)RV.requisitionId;

        r.changeStatus(rid, 2002);

        return 1;

    }

    public int InsertDelegation(WCF_Delegate v)
    {
        DelegateEmployeeBLL DE = new DelegateEmployeeBLL();
        string empname = v.employeeName;
        int ecode = DE.findEmpCode(empname);

        delegateEmployee d = new delegateEmployee();

        d.employeeId = ecode;
        DateTime fromdatee = Convert.ToDateTime(v.fromDate);
        System.Diagnostics.Debug.Write(fromdatee);
        d.fromDate = fromdatee;
        DateTime toDate = Convert.ToDateTime(v.toDate);
        d.toDate = toDate;
        d.reason = v.reason;
        d.status = v.status;

        DE.startDelegatation(d);
        user.changeDelegateEmployeeUserRoleId(ecode, 11006);

        return 1;



    }

    public string UpdateDelegation(WCF_Delegate D)
    {
        DelegateEmployeeBLL DE = new DelegateEmployeeBLL();
        string empname = D.employeeName.ToString();
        int ecode = DE.findEmpCode(empname);
        delegateEmployee d = DE.GetDelegatedEmployee(ecode);

        user.changeDelegateEmployeeUserRoleId(ecode, 11004);
        DE.endDelegationForMobile(d.delegationId);
        return D.employeeName.ToString();
    }


    //CollectionPoints

    public string ChangeCollectionPoint(WCF_Collectionpoint v)
    {
        CollectionPointBLL cp = new CollectionPointBLL();
        //CollectionPoint cp = new CollectionPoint();
        cp.changeCollectionPoint(v.departmentCode, v.collectionPointId);
        return v.collectionPointId.ToString();
    }

    //CreateRequisition

    public string CreateRequisition(List<WCF_createRequisition> cr)
    {
        Requisitioin req = new Requisitioin();

        string deptcode = "";

        string userid = "";

        List<requisitionDetail> listrd = new List<requisitionDetail>();

        foreach (WCF_createRequisition r in cr)
        {
            deptcode = r.departmentCode;
            userid = r.employeeId;
            string itemcode = r.itemCode;
            string qty = r.qtyNeeded;

            requisitionDetail rd = new requisitionDetail();
            rd.itemCode = itemcode;
            rd.qtyNeeded = Int32.Parse(qty);
            rd.qtyActual = 0;
            rd.qtyOutstaning = 0;
            rd.outstandingField = false;

            listrd.Add(rd);


        }

        //Need to Convert WCF Variable to Entity Var
        //requisition rr = new requisition();
        //rr.departmentCode = cr.ElementAt(0).departmentCode;
        //rr.employeeId = Int32.Parse(cr.ElementAt(0).employeeId);

        string dcode = cr.ElementAt(0).departmentCode;
        int uid = Int32.Parse(cr.ElementAt(0).employeeId);


        req.addrequisition(dcode, uid, 2000, DateTime.Now, true, listrd);

        string result = "Success";

        return result;
    }

    //ChangeRetrieval
    public string ChangeRetrieval(WCF_ChangeRetrival cn)
    {


        string itemcode = cn.itemCode;
        int adjqty = cn.adjustmentQuantity;
        string type = cn.type;
        string reason = cn.reason;
        int rid = cn.retrievalId;
        string dcode = cn.departmentCode;
        int actqty = cn.actualQuantity;
        int userId = cn.userId;

        retBLL.comfirmRetrievalDetails(rid, itemcode, dcode, actqty);
        List<adjustmentDetail> list = new List<adjustmentDetail>();
        List<adjustmentDetail> Alist = ABLL.CreateAdjCart(itemcode, adjqty, type, reason, list);
        ABLL.CreateAdjustment(Alist, userId);

        return dcode.ToString();

    }

    //UpdateDisbursement

    public string updateDisbursement(WCF_ChangeDisbursement up)
    {
        string itemDes = up.itemDescription;
        int recqty = up.receivedQuantity;
        string type = up.type;
        string reason = up.reason;
        int disid = up.disbursementId;
        string dcode = up.departmentCode;
        int adqty = up.adjustmentQuantity;
        string user = up.userId;

        string itemCode = db.getItemcode(itemDes);

        int userId = db.getUserid(user);

        db.changeDisbursementQuantityformob(disid, itemCode, recqty, dcode);
        //db.changeDisbursementQuantityformob(disid, itemCode, recqty, dcode);
        List<adjustmentDetail> list = new List<adjustmentDetail>();
        List<adjustmentDetail> Alist = ABLL.CreateAdjCart(itemCode, adqty, type, reason, list);
        ABLL.CreateAdjustment(Alist, userId);

        return userId.ToString();

    }

    public bool EndDelegation(string empId)
    {
        DelegateEmployeeBLL DE = new DelegateEmployeeBLL();
        delegateEmployee d = DE.GetDelegatedEmployee(Convert.ToInt32(empId));
        user.changeDelegateEmployeeUserRoleId(Convert.ToInt32(empId), 11004);
        DE.endDelegationForMobile(d.delegationId);
        return true;
    }

}