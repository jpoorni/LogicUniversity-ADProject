using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team8_ADProjectLUStationerySystem;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebGet(UriTemplate = "/Repid/{depCode}", ResponseFormat = WebMessageFormat.Json)]
    int getCurrentRepID(string depCode);

    [OperationContract]
    [WebGet(UriTemplate = "/Deptlist", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_department> getAllDepartment();

    [OperationContract]
    [WebGet(UriTemplate = "/Dept", ResponseFormat = WebMessageFormat.Json)]
    WCF_department getOne();

    [OperationContract]
    [WebGet(UriTemplate = "/Departments", ResponseFormat = WebMessageFormat.Json)]
    List<string> getDept();
    [OperationContract]
    [WebGet(UriTemplate = "/ReNoByCategory/{retId}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_RetriveViewbyCategory> TotalRetriveByCategory(string retId);

    [OperationContract]
    [WebGet(UriTemplate = "/ReNoByDept/{categoryId}/{retId}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_RetriveViewbyDept> RetriveByDept(string categoryId, string retId);


    [OperationContract]
    [WebGet(UriTemplate = "/AllRetrievalId", ResponseFormat = WebMessageFormat.Json)]
    List<int> getAllRetrievalId();

    [OperationContract]
    [WebGet(UriTemplate = "/DisForClerk", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_DisForClerk> ViewDisForClerk();

    [OperationContract]
    [WebGet(UriTemplate = "/DisbyDeptForClerk/{deptCode}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_DisbyDeptForClerk> ViewDisbyDeptForClerk(string deptCode);

    [OperationContract]
    [WebGet(UriTemplate = " /DisWithoutItemForClerk/{disId}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_DisWithoutItemForClerk> ViewDisWithoutItemForClerk(string disId);

    [OperationContract]
    [WebGet(UriTemplate = "/DisbursementDetailsListforMobile/{disId}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_DisbursementDetailsListforMobile> DisbursementDetailsListforMobile(string disId);

    [OperationContract]
    [WebGet(UriTemplate = "/ApproveAdjust/{aId}", ResponseFormat = WebMessageFormat.Json)]
    bool ApproveAdjustment(string aId);

    [OperationContract]
    [WebGet(UriTemplate = "/ChangeStatus/{PoId}/{status}", ResponseFormat = WebMessageFormat.Json)]
    bool ChangeStatus(string PoId, string status);

    [OperationContract]
    [WebGet(UriTemplate = "/RejectAdjustment/{aId}", ResponseFormat = WebMessageFormat.Json)]
    bool RejectAdjustment(string aId);

    //[OperationContract]
    //[WebGet(UriTemplate = "/ConfirmRetrieval/{RetrievalId}", ResponseFormat = WebMessageFormat.Json)]
    //bool ConfirmRetrieval(string RetrievalId);
    //[OperationContract]
    //[WebGet(UriTemplate = "/Viewrequisition/{empid}", ResponseFormat = WebMessageFormat.Json)]
    //List<WCF_RequisitionView> viewRequistion(string empid);

    //[OperationContract]
    //[WebInvoke(UriTemplate = "InsertProduct", Method = "POST",
    //    RequestFormat = WebMessageFormat.Json,
    //    ResponseFormat = WebMessageFormat.Json)]
    // void InsertProduct(WCF_department r);

    //
    //ChangaePODetails
    [OperationContract]
    [WebGet(UriTemplate = "/ChangePODetails/{PodId}/{reqty}", ResponseFormat = WebMessageFormat.Json)]
    bool ChangaePODetails(string PodId, string reqty);

    //DefaultReorderQuantity
    [OperationContract]
    [WebGet(UriTemplate = "/DefaultReorderQuantity/{itemcode}", ResponseFormat = WebMessageFormat.Json)]
    int? DefaultReorderQuantity(string itemcode);

    //Confiem Po Status

    [OperationContract]
    [WebGet(UriTemplate = "/ConfirmPOStatus/{poid}", ResponseFormat = WebMessageFormat.Json)]
    int ConfrimPOStatus(string poid);

    //Post Method

    [OperationContract]
    [WebGet(UriTemplate = "/Confirmretrieval/{rid}", ResponseFormat = WebMessageFormat.Json)]
    bool Confirmretrieval(string rid);


    [OperationContract]
    [WebGet(UriTemplate = "/getPOIds", ResponseFormat = WebMessageFormat.Json)]
    List<int> getPOIds();

    [OperationContract]
    [WebGet(UriTemplate = "/POdetails/{poid}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_POdetails> POdetails(string poid);


    [OperationContract]
    [WebInvoke(UriTemplate = "/CreatePO", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    bool CreatePO(List<WCF_CreatePO> cp);

    //[OperationContract]
    //[WebGet(UriTemplate = "/EndDelegation/{empid}", ResponseFormat = WebMessageFormat.Json)]
    //bool EndDelegation(string empid);

    [OperationContract]
    [WebGet(UriTemplate = "/getAllClerks", ResponseFormat = WebMessageFormat.Json)]
    List<string> getAllClerks();

    [OperationContract]
    [WebGet(UriTemplate = "/getDisIds/{dcode}", ResponseFormat = WebMessageFormat.Json)]
    List<int> getDisIds(string dcode);

    [OperationContract]
    [WebGet(UriTemplate = "/confirmDisbursement/{disId}/{deptcode}", ResponseFormat = WebMessageFormat.Json)]
    bool confirmDisbursement(string disId, string deptcode);

    //Confiem Po Status

    [OperationContract]
    [WebGet(UriTemplate = "/RejectPOStatus/{poid}", ResponseFormat = WebMessageFormat.Json)]
    int RejectPOStatus(string poid);


}
[DataContract]
public class WCF_CreatePO
{
    string supplierCode;
    int userId;
    string itemCode;
    int? orderedQuantity;


    public WCF_CreatePO(string supplierCode, int userId, string itemCode, int? orderedQuantity)
    {
        this.supplierCode = supplierCode;
        this.userId = userId;
        this.itemCode = itemCode;
        this.orderedQuantity = orderedQuantity;
    }

    [DataMember]
    public string SupplierCode
    {
        get { return supplierCode; }
        set { supplierCode = value; }
    }

    [DataMember]
    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }



    [DataMember]
    public string ItemCode
    {
        get { return itemCode; }
        set { itemCode = value; }
    }

    [DataMember]
    public int? OrderedQuantity
    {
        get { return orderedQuantity; }
        set { orderedQuantity = value; }
    }
}

[DataContract]
public class WCF_POdetails
{

    int? purchaseDetail_Id;
    string itemdesp;
    int? orderedQuantity;

    public WCF_POdetails(int? purchaseDetail_Id, string itemdesp, int? orderedQuantity)
    {
        this.purchaseDetail_Id = purchaseDetail_Id;
        this.itemdesp = itemdesp;
        this.orderedQuantity = orderedQuantity;
    }


    [DataMember]
    public int? PurchaseDetail_Id
    {
        get { return purchaseDetail_Id; }
        set { purchaseDetail_Id = value; }
    }



    [DataMember]
    public string Itemdesp
    {
        get { return itemdesp; }
        set { itemdesp = value; }
    }

    [DataMember]
    public int? OrderedQuantity
    {
        get { return orderedQuantity; }
        set { orderedQuantity = value; }
    }
}
[DataContract]
public class WCF_department
{

    string departmentCode;
    string departmentName;
    string contactName;
    int telephoneNo;
    string faxNo;
    string headName;
    int collectionPointId;
    string photos;
    int representativeID;

    public WCF_department(string departmentCode, string departmentName, string contactName, int telephoneNo, string headName, int collectionPointId, string photos, string faxNo, int representativeID)
    {
        this.departmentCode = departmentCode;
        this.departmentName = departmentName;
        this.contactName = contactName;
        this.telephoneNo = telephoneNo;
        this.faxNo = faxNo;
        this.headName = headName;
        this.collectionPointId = collectionPointId;
        this.photos = photos;
        this.representativeID = representativeID;
    }


    [DataMember]
    public string DepartmentCode
    {
        get { return departmentCode; }
        set { departmentCode = value; }
    }

    [DataMember]
    public string DepartmentName
    {
        get { return departmentName; }
        set { departmentName = value; }
    }

    [DataMember]
    public string ContactName
    {
        get { return contactName; }
        set { contactName = value; }
    }

    [DataMember]
    public int TelephoneNo
    {
        get { return telephoneNo; }
        set { telephoneNo = value; }
    }

    [DataMember]
    public string FaxNo
    {
        get { return faxNo; }
        set { faxNo = value; }
    }

    [DataMember]
    public string HeadName
    {
        get { return headName; }
        set { headName = value; }
    }
    [DataMember]
    public int CollectionPointId
    {
        get { return collectionPointId; }
        set { collectionPointId = value; }
    }
    [DataMember]
    public string Photos
    {
        get { return photos; }
        set { photos = value; }
    }

    [DataMember]
    public int RepresentativeID
    {
        get { return representativeID; }
        set { representativeID = value; }
    }
}

//[DataContract]
//public class WCF_RequisitionView
//{
//    public string itemDescription;
//    public int? qtyNeeded;
//    public string statusDescription;

//    public WCF_RequisitionView(string itemDescription, int? qtyNeeded, string statusDescription)
//    {
//        this.itemDescription = itemDescription;
//        this.qtyNeeded = qtyNeeded;
//        this.statusDescription = statusDescription;
//    }

//    [DataMember]
//    public string ItemDescription
//    {
//        get { return itemDescription; }
//        set { itemDescription = value; }
//    }

//    [DataMember]
//    public int? QtyNeeded
//    {
//        get { return qtyNeeded; }
//        set { qtyNeeded = value; }
//    }

//    [DataMember]
//    public string StatusDescription
//    {
//        get { return statusDescription; }
//        set { statusDescription = value; }
//    }
//}

[DataContract]
public class WCF_RetriveViewbyCategory
{

    int? categoryId;
    string categoryName;
    int? actualQuantity;

    public WCF_RetriveViewbyCategory(int? categoryId, string categoryName, int? actualQuantity)
    {
        this.categoryId = categoryId;
        this.categoryName = categoryName;
        this.actualQuantity = actualQuantity;
    }


    [DataMember]
    public int? CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }



    [DataMember]
    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    [DataMember]
    public int? ActualQuantity
    {
        get { return actualQuantity; }
        set { actualQuantity = value; }
    }
}
//WCF_RetriveViewbyDept
[DataContract]
public class WCF_RetriveViewbyDept
{
    int? retrievalId;
    string departmentId;
    string depetName;
    string itemCode;
    string itemDescription;
    int? actualQuantity;

    public WCF_RetriveViewbyDept(int? retrievalId, string departmentId, string depetName, string itemCode, string itemDescripion, int? actualQuantity)
    {
        this.retrievalId = retrievalId;
        this.departmentId = departmentId;
        this.depetName = depetName;
        this.itemCode = itemCode;
        this.itemDescription = itemDescripion;
        this.actualQuantity = actualQuantity;
    }

    [DataMember]
    public int? RetrievalId
    {
        get { return retrievalId; }
        set { retrievalId = value; }
    }

    [DataMember]
    public string DepartmentId
    {
        get { return departmentId; }
        set { departmentId = value; }
    }

    [DataMember]
    public string DepetName
    {
        get { return depetName; }
        set { depetName = value; }
    }

    [DataMember]
    public string ItemCode
    {
        get { return itemCode; }
        set { itemCode = value; }
    }

    [DataMember]
    public string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    [DataMember]
    public int? ActualQuantity
    {
        get { return actualQuantity; }
        set { actualQuantity = value; }
    }
}
[DataContract]
public class WCF_DisForClerk
{

    string departmentId;
    string depetName;
    int? totalDisburseIdNo;

    public WCF_DisForClerk(string departmentId, string depetName, int? totalDisburseIdNo)
    {
        this.departmentId = departmentId;
        this.depetName = depetName;
        this.totalDisburseIdNo = totalDisburseIdNo;
    }

    [DataMember]
    public string DepartmentId
    {
        get { return departmentId; }
        set { departmentId = value; }
    }

    [DataMember]
    public string DepetName
    {
        get { return depetName; }
        set { depetName = value; }
    }

    [DataMember]
    public int? TotalDisburseIdNo
    {
        get { return totalDisburseIdNo; }
        set { totalDisburseIdNo = value; }
    }
}
[DataContract]
public class WCF_DisbyDeptForClerk
{
    int? disbursementID;
    string departmentCode;
    string departmentName;
    string employeeName;
    string collectionDate;
    string collectionPointName;

    public WCF_DisbyDeptForClerk(int? disbursementID, string departmentCode, string departmentName, string employeeName, string collectionDate, string collectionPointName)
    {
        this.disbursementID = disbursementID;
        this.departmentCode = departmentCode;
        this.departmentName = departmentName;
        this.employeeName = employeeName;
        this.collectionDate = collectionDate;
        this.collectionPointName = collectionPointName;
    }
    [DataMember]
    public int? DisbursementID
    {
        get { return disbursementID; }
        set { disbursementID = value; }
    }

    [DataMember]
    public string DepartmentCode
    {
        get { return departmentCode; }
        set { departmentCode = value; }
    }

    [DataMember]
    public string DepartmentName
    {
        get { return departmentName; }
        set { departmentName = value; }
    }

    [DataMember]
    public string EmployeeName
    {
        get { return employeeName; }
        set { employeeName = value; }
    }

    [DataMember]
    public string CollectionDate
    {
        get { return collectionDate; }
        set { collectionDate = value; }
    }

    [DataMember]
    public string CollectionPointName
    {
        get { return collectionPointName; }
        set { collectionPointName = value; }
    }

}
[DataContract]
public class WCF_DisWithoutItemForClerk
{
    string departmentName;
    int? employeeId;
    string employeeName;
    int? collectionPointId;
    string collectionPointName;
    DateTime? collectionDate;

    public WCF_DisWithoutItemForClerk(string departmentName, int? employeeId, string employeeName, int? collectionPointId, string collectionPointName, DateTime? collectionDate)
    {
        this.departmentName = departmentName;
        this.employeeId = employeeId;
        this.employeeName = employeeName;
        this.collectionPointId = collectionPointId;
        this.collectionPointName = collectionPointName;
        this.collectionDate = collectionDate;
    }
    [DataMember]
    public string DepartmentName
    {
        get { return departmentName; }
        set { departmentName = value; }
    }

    [DataMember]
    public int? EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    [DataMember]
    public string EmployeeName
    {
        get { return employeeName; }
        set { employeeName = value; }
    }

    [DataMember]
    public int? CollectionPointId
    {
        get { return collectionPointId; }
        set { collectionPointId = value; }
    }

    [DataMember]
    public string CollectionPointName
    {
        get { return collectionPointName; }
        set { collectionPointName = value; }
    }

    [DataMember]
    public DateTime? CollectionDate
    {
        get { return collectionDate; }
        set { collectionDate = value; }
    }
}

[DataContract]
public class WCF_DisbursementDetailsListforMobile
{

    string itemDes;
    int? reqQty;
    int? receivedQuantity;

    public WCF_DisbursementDetailsListforMobile(string itemDes, int? reqQty, int? receivedQuantity)
    {
        this.itemDes = itemDes;
        this.reqQty = reqQty;
        this.receivedQuantity = receivedQuantity;
    }

    [DataMember]
    public string ItemDes
    {
        get { return itemDes; }
        set { itemDes = value; }
    }

    [DataMember]
    public int? ReqQty
    {
        get { return reqQty; }
        set { reqQty = value; }
    }

    [DataMember]
    public int? ReceivedQuantity
    {
        get { return receivedQuantity; }
        set { receivedQuantity = value; }
    }
}