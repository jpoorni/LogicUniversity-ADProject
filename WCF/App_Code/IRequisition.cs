using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRequisition" in both code and config file together.
[ServiceContract]
public interface IRequisition
{
	 [OperationContract]
    [WebGet(UriTemplate = "/Requisitiondetails/{reqID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_RequisitionViewDetails> Requisitiondetails(string reqID);

    [OperationContract]
    [WebGet(UriTemplate = "/Requisitionlist/{empid}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_RequisitionView> Requistionlist(string empid);

    //ViewDisbursementlist for Rep
    [OperationContract]
    [WebGet(UriTemplate = "/Viewdisbursement/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Viewdisbursement> Viewdisbursement(string deptID);

    //DepartmentHead
    [OperationContract]
    [WebGet(UriTemplate = "/Viewemployee/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Viewemployee> Viewemployee(string deptID);

    [OperationContract]
    [WebGet(UriTemplate = "/Viewemployeereq/{reqid}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_empreqlist> Employeereq(string reqid);

    [OperationContract]
    [WebGet(UriTemplate = "/Viewrequisitionbydept/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Viewemployee> Viewrequisitionbydept(string deptID);

    //Employee
    [OperationContract]
    [WebGet(UriTemplate = "/employeeList/{deptID}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Employee> employeeList(string deptID);

    [OperationContract]
    [WebGet(UriTemplate = "/getEmployee/{empid}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Employee getEmployee(string empid);

    //Delegate

    [OperationContract]
    [WebGet(UriTemplate = "/getDelegate/{deptcode}", ResponseFormat = WebMessageFormat.Json)]
    WCF_CurrentDelegate getDelegate(string deptcode);

   

    //Collectionpoint
    [OperationContract]
    [WebGet(UriTemplate = "/getCollectionbydept/{deptcode}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Collectionpoint getCollectionbydept(string deptcode);

    [OperationContract]
    [WebGet(UriTemplate = "/getCollectionbyid/{cid}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Collectionpoint getCollectionbyid(string cid);

    //All items

    [OperationContract]
    [WebGet(UriTemplate = "/getallitems", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_itemList> getallitems();

    [OperationContract]
    [WebGet(UriTemplate = "/getItemsByCategory/{cName}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_itemList> getItemsByCategory(string cName);

    //Supervisor & Manager

    [OperationContract]
    [WebGet(UriTemplate = "/adjustmentList/{id}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Adjustment> adjustmentList(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/adjustmentDetails/{id}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_AdjustmentDetails> adjustmentDetails(string id);

    //Purchase order
    [OperationContract]
    [WebGet(UriTemplate = "/purchaseorderlist/{id}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Purcahseorder> purchaseorderlist(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/purchaseorderdetails/{id}", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Purcahseorderdetails> purchaseorderdetails(string id);

    //Supplier..
    [OperationContract]
    [WebGet(UriTemplate = "/getallsupplier", ResponseFormat = WebMessageFormat.Json)]
    List<WCF_Supplier> getallsupplier();

    [OperationContract]
    [WebGet(UriTemplate = "/getonesupplier/{id}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Supplier getonesupplier(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/EndDelegation/{empId}", ResponseFormat = WebMessageFormat.Json)]
    bool EndDelegation(string empId);


    //

    ////Post Method

    //Approve

    [OperationContract]
    [WebInvoke(UriTemplate = "/ApproveRequisition", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    int ApproveRequisition(WCF_Viewemployee v);

    //Reject
     [OperationContract]
    [WebInvoke(UriTemplate = "/RejectRequisition", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    int RejectRequisition(WCF_Viewemployee v);
    //AddDelegate

    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertDelegation", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    int InsertDelegation(WCF_Delegate v);

    //UpdateDelgate

    [OperationContract]
    [WebInvoke(UriTemplate = "/EndDelegation", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    string UpdateDelegation(WCF_Delegate d);

    //ChangeCollectionPoint

    [OperationContract]
    [WebInvoke(UriTemplate = "/ChangeCollectionPoint", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    string ChangeCollectionPoint(WCF_Collectionpoint v);

    //CreateRequisition

    [OperationContract]
    [WebInvoke(UriTemplate = "/CreateRequisition", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    string CreateRequisition(List<WCF_createRequisition> cr);


    //UpdateDisbursement

    [OperationContract]
    [WebInvoke(UriTemplate = "/updateDisbursement", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    string updateDisbursement(WCF_ChangeDisbursement up);

    //ChangeRetrival

    [OperationContract]
    [WebInvoke(UriTemplate = "/ChangeRetrieval", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    string ChangeRetrieval(WCF_ChangeRetrival cn);

    //Login Get Method

    [OperationContract]
    [WebGet(UriTemplate = "/Login/{uname}/{pwd}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Login Login(string uname, string pwd);

   
}


//Login WCF Object

[DataContract]
public class WCF_Login
{

     public string username;
        public string password;
        public int userId;
        public int roleId;
        public string roleDescription;
        public string departmentCode;
        public string departmentName;


        public WCF_Login(string username, string password, int userId, int roleId, string roleDescription, string departmentCode, string departmentName)
        {
           this.username=username;
            this.password=password;
            this.userId=userId;
            this.roleId=roleId;
            this.roleDescription=roleDescription;
            this.departmentCode=departmentCode;
            this.departmentName=departmentName;
        }

    

    [DataMember]
        public string Username
    {
        get { return username; }
        set { username = value; }
    }
    [DataMember]
    public string Password
    {
        get { return password; }
        set { password = value; }
    }


    [DataMember]
    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    [DataMember]
    public int RoleId
    {
        get { return roleId; }
        set { roleId = value; }
    }

    [DataMember]
    public string RoleDescription
    {
        get { return roleDescription; }
        set { roleDescription = value; }
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
}





    [DataContract]
    public class WCF_RequisitionView
    {

        public int? requisitionId;
        public string requisitionDate;
        public int? totalQty;


        public WCF_RequisitionView(int? requisitionId, string requisitionDate, int? totalQty)
        {
            this.requisitionId = requisitionId;
            this.requisitionDate=requisitionDate;
            this.totalQty=totalQty;
        }

        [DataMember]
        public int? RequisitionId
        {
            get { return requisitionId; }
            set { requisitionId = value; }
        }

        [DataMember]
        public string RequisitionDate
        {
            get { return requisitionDate; }
            set { requisitionDate = value; }
        }


        [DataMember]
        public int? TotalQty
        {
            get { return totalQty; }
            set { totalQty = value; }
        }
    }

    [DataContract]
    public class WCF_RequisitionViewDetails
    {
        public string itemDescription;
        public int? qtyNeeded;
        public int? qtyAcutal;
        public string statusDescription;


        public WCF_RequisitionViewDetails(string itemDescription, int? qtyNeeded, int? qtyAcutal, string statusDescription)
        {
            this.itemDescription = itemDescription;
            this.qtyNeeded = qtyNeeded;
            this.statusDescription = statusDescription;
            this.qtyAcutal=qtyAcutal;
        }

       
        [DataMember]
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        [DataMember]
        public int? QtyNeeded
        {
            get { return qtyNeeded; }
            set { qtyNeeded = value; }
        }

         [DataMember]
        public int? QtyAcutal
        {
            get { return qtyAcutal; }
            set { qtyAcutal = value; }
        }

        [DataMember]
        public string StatusDescription
        {
            get { return statusDescription; }
            set { statusDescription = value; }
        }

       
    }


    [DataContract]
    public class WCF_Viewdisbursement
    {
        public int? disbursementID;
        public string itemCode;
        public string itemDescription;
        public int? reqQuantity;
        public int  receivedQuantity;
        public string departmentCode;

        public WCF_Viewdisbursement(int? disbursementID, string itemCode, string itemDescription, int? reqQuantity)
        {
            this.disbursementID = disbursementID;
            this.itemCode = itemCode;
            this.itemDescription = itemDescription;
            this.reqQuantity = reqQuantity;
        }

        public WCF_Viewdisbursement(int? disbursementID, string itemCode, int receivedQuantity,string departmentCode)
        {
            this.disbursementID = disbursementID;
            this.itemCode = itemCode;
            this.receivedQuantity = receivedQuantity;
            this.departmentCode = departmentCode;
        }

        [DataMember]
        public int? DisbursementID
        {
            get { return disbursementID; }
            set { disbursementID = value; }
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
        public int? ReqQuantity
        {
            get { return reqQuantity; }
            set { reqQuantity = value; }
        }

        [DataMember]
        public int ReceivedQuantity
        {
            get { return receivedQuantity; }
            set { receivedQuantity = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }


    }

//Department Head

    [DataContract]
    public class WCF_Viewemployee
    {
        public int? requisitionId;
        public string requisitionDate;
        public string statusDescription;
        public int? employeeID;
        public string employeeName;

        public WCF_Viewemployee(int? requisitionId, int? employeeID, string employeeName, string requisitionDate, string statusDescription)
        {
            this.requisitionId = requisitionId;
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.requisitionDate = requisitionDate;
            this.statusDescription = statusDescription;
        }


        [DataMember]
        public int? RequisitionId
        {
            get { return requisitionId; }
            set { requisitionId = value; }
        }


        [DataMember]
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        [DataMember]
        public int? EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string RequisitionDate
        {
            get { return requisitionDate; }
            set { requisitionDate = value; }
        }
        [DataMember]
        public string StatusDescription
        {
            get { return statusDescription; }
            set { statusDescription = value; }
        }


    }


    [DataContract]
    public class WCF_empreqlist
    {
        public string category;
        public string itemDescription;
        public int? qtyNeeded;


        public WCF_empreqlist(string category, string itemDescription, int? qtyNeeded)
        {
            this.category = category;
            this.itemDescription = itemDescription;
            this.qtyNeeded = qtyNeeded;
        }


        [DataMember]
        public string Category
        {
            get { return category; }
            set { category = value; }
        }


        [DataMember]
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        [DataMember]
        public int? QtyNeeded
        {
            get { return qtyNeeded; }
            set { qtyNeeded = value; }
        }


    }

    [DataContract]
    public class WCF_itemList
    {
        public string itemcode;
        public int? categoryId;
        public string itemDescription;
        public int? reorderLevel;
        public int? reorderQuantity;
        public string uom;
        public double? tenderPrice;
        public string bin;
        public int? quantity;
        public string photos;


        public WCF_itemList(string itemcode, int? categoryId, string itemDescription, int? reorderLevel, int? reorderQuantity, string uom, double? tenderPrice, string bin, int? quantity, string photos)
        {
            this.itemcode = itemcode;
            this.categoryId = categoryId;
            this.itemDescription = itemDescription;
            this.reorderLevel = reorderLevel;
            this.reorderQuantity = reorderQuantity;
            this.uom=uom;
            this.tenderPrice=tenderPrice;
            this.bin = bin;
            this.quantity = quantity;
            this.photos = photos;

        }


        [DataMember]
        public string Itemcode
        {
            get { return itemcode; }
            set { itemcode = value; }
        }    

        [DataMember]
        public int? CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        [DataMember]
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        [DataMember]
        public int? ReorderLevel
        {
            get { return reorderLevel; }
            set { reorderLevel = value; }
        }

        [DataMember]
        public int? ReorderQuantity
        {
            get { return reorderQuantity; }
            set { reorderQuantity = value; }
        }

        [DataMember]
        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }

        [DataMember]
        public double? TenderPrice
        {
            get { return tenderPrice; }
            set { tenderPrice = value; }
        }

        [DataMember]
        public string Bin
        {
            get { return bin; }
            set { bin = value; }
        }

        [DataMember]
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Photos
        {
            get { return photos; }
            set { photos = value; }
        }


    }

    [DataContract]
    public class WCF_Employee
    {
        public int employeeId;
        public string employeeName;
        public string departmentCode;
        public int? phoneNumber;
        public string email;
        public string status;
        
        private string photo;
     
       

        public WCF_Employee(int employeeId, string employeeName, string departmentCode, int? phoneNumber, string email, string status, string photo)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.departmentCode = departmentCode;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.status = status;
            this.photo = photo;
           

        }

       

        


        [DataMember]
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        [DataMember]
        public string  EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        [DataMember]
        public int? PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

       

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

       

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

       

        [DataMember]
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }


    }


    [DataContract]
    public class WCF_Collectionpoint
    {
        public int collectionPointId;
        public string collectionPointName;
        public string collectionPointDescription;
        public string latitude;
        public string longtitude;
        public TimeSpan? collectionTime;

        public string departmentCode;
        
        public WCF_Collectionpoint(int collectionPointId, string collectionPointName, string collectionPointDescription, string latitude, string longtitude, TimeSpan? collectionTime)
        {
            this.collectionPointId = collectionPointId;
            this.collectionPointName = collectionPointName;
            this.collectionPointDescription = collectionPointDescription;
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.collectionTime = collectionTime;

        }

       public WCF_Collectionpoint(int collectionPointId,string deptcode)
        {
            this.collectionPointId = collectionPointId;
            this.departmentCode = deptcode;
        }


        [DataMember]
        public int CollectionPointId
        {
            get { return collectionPointId; }
            set { collectionPointId = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        [DataMember]
        public string CollectionPointName
        {
            get { return collectionPointName; }
            set { collectionPointName = value; }
        }

       

        [DataMember]
        public string CollectionPointDescription
        {
            get { return collectionPointDescription; }
            set { collectionPointDescription = value; }
        }



        [DataMember]
        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }



        [DataMember]
        public string Longtitude
        {
            get { return longtitude; }
            set { longtitude = value; }
        }



        [DataMember]
        public TimeSpan? CollectionTime
        {
            get { return collectionTime; }
            set { collectionTime = value; }
        }


    }


//AdjustmentDetails

    [DataContract]
    public class WCF_Adjustment
    {
        public int adjustmentId;
        public double? totalAmount;
        public string status;
        public string authorizedPerson;
        public int? employeeId;
        public string adjustDate;
        

        public WCF_Adjustment(int adjustmentId, double? totalAmount, string status, string authorizedPerson, int? employeeId, string adjustDate)
        {
            this.adjustmentId = adjustmentId;
            this.totalAmount = totalAmount;
            this.status = status;
            this.authorizedPerson = authorizedPerson;
            this.employeeId = employeeId;
            this.adjustDate = adjustDate;

        }

        


        [DataMember]
        public int AdjustmentId
        {
            get { return adjustmentId; }
            set { adjustmentId = value; }
        }

        [DataMember]
        public double? TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }



        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }



        [DataMember]
        public string AuthorizedPerson
        {
            get { return authorizedPerson; }
            set { authorizedPerson = value; }
        }



        [DataMember]
        public int? EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }



        [DataMember]
        public string AdjustDate
        {
            get { return adjustDate; }
            set { adjustDate = value; }
        }


    }

    [DataContract]
    public class WCF_AdjustmentDetails
    {
        public int adjustmentDetailsId;
        public int adjustmentId;
      
        public string itemCode;
        public int? adjustmentQuantity;
        public double? adjustmentAmount;
        public string type;

        public string reason;


        public WCF_AdjustmentDetails(int adjustmentDetailsId, int adjustmentId, string itemCode, int? adjustmentQuantity, double? adjustmentAmount, string type, string reason)
        {
            this.adjustmentDetailsId = adjustmentDetailsId;
            this.adjustmentId = adjustmentId;
            this.itemCode = itemCode;
            this.adjustmentQuantity = adjustmentQuantity;
            this.adjustmentAmount = adjustmentAmount;
            this.type = type;
            this.reason = reason;

        }


        [DataMember]
        public int AdjustmentDetailsId
        {
            get { return adjustmentDetailsId; }
            set { adjustmentDetailsId = value; }
        }

        [DataMember]
        public int AdjustmentId
        {
            get { return adjustmentId; }
            set { adjustmentId = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }


        [DataMember]
        public int? AdjustmentQuantity
        {
            get { return adjustmentQuantity; }
            set { adjustmentQuantity = value; }
        }

        [DataMember]
        public double? AdjustmentAmount
        {
            get { return adjustmentAmount; }
            set { adjustmentAmount = value; }
        }

        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }



        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

    }


//purchase order

    [DataContract]
    public class WCF_Purcahseorder
    {
        public int purchaseorderno;


        public string supplierCode;
        public string purchaseDate;
        public string status;
        public int? userId;

        public double? totalAmount;



        public WCF_Purcahseorder(int purchaseorderno, string supplierCode, string purchaseDate, string status, int? userId, double? totalAmount)
        {
            this.purchaseorderno = purchaseorderno;
            this.supplierCode = supplierCode;
            this.purchaseDate = purchaseDate;
            this.status = status;
            this.userId = userId;
            this.totalAmount = totalAmount;      

        }

       


        [DataMember]
        public int Purchaseorderno
        {
            get { return purchaseorderno; }
            set { purchaseorderno = value; }
        }

       
        [DataMember]
        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }


        [DataMember]
        public string PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public int? UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        [DataMember]
        public double? TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

    }

    //purchase order

    [DataContract]
    public class WCF_Purcahseorderdetails
    {
        public int purchaseDetail_Id;
        public int purchaseorderno;


        public string itemCode;

        public int? orderedQuantity;

        public double? price;
        public double? amount;
        public int? receivedQuantity;
       



        public WCF_Purcahseorderdetails(int purchaseDetail_Id, int purchaseorderno, string itemCode, int? orderedQuantity, double? price, double? amount, int? receivedQuantity)
        {
            this.purchaseDetail_Id = purchaseDetail_Id;
            this.purchaseorderno = purchaseorderno;
            this.itemCode = itemCode;
            this.orderedQuantity = orderedQuantity;
            this.price = price;
            this.amount = amount;
            this.receivedQuantity = receivedQuantity;

        }

        
        [DataMember]
        public int PurchaseDetail_Id
        {
            get { return purchaseDetail_Id; }
            set { purchaseDetail_Id = value; }
        }

        [DataMember]
        public int Purchaseorderno
        {
            get { return purchaseorderno; }
            set { purchaseorderno = value; }
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

        [DataMember]
        public double? Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public double? Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        [DataMember]
        public int? ReceivedQuantity
        {
            get { return receivedQuantity; }
            set { receivedQuantity = value; }
        }

    }

//Supplier:


    [DataContract]
    public class WCF_Supplier
    {
        public string supplierCode;
        public string gstRegistrationNumber;


        public string supplierName;
        public string contactName;

        public int? phoneNo;
        public string faxNo;
        public string address;

        public int? supplierRank;




        public WCF_Supplier(string supplierCode, string gstRegistrationNumber, string supplierName, string contactName, int? phoneNo, string faxNo, string address, int? supplierRank)
        {
            this.supplierCode = supplierCode;
            this.gstRegistrationNumber = gstRegistrationNumber;
            this.supplierName = supplierName;
            this.contactName = contactName;
            this.phoneNo = phoneNo;
            this.faxNo = faxNo;
            this.address = address;
            this.supplierRank = supplierRank;

        }


        [DataMember]
        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }

        [DataMember]
        public string GstRegistrationNumber
        {
            get { return gstRegistrationNumber; }
            set { gstRegistrationNumber = value; }
        }


        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }


        [DataMember]
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        [DataMember]
        public int? PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        [DataMember]
        public string FaxNo
        {
            get { return faxNo; }
            set { faxNo = value; }
        }


        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        
        [DataMember]
        public int? SupplierRank
        {
            get { return supplierRank; }
            set { supplierRank = value; }
        }

    }
    
    

//Get Delegate

    [DataContract]
    public class WCF_Delegate
    {
        public int delegationId;
        public int? employeeId;
        public string employeeName;
        public string fromDate;
        public string toDate;
        public string reason;
        public string status;

        public WCF_Delegate(string employeeName)
        {
            this.employeeName = employeeName;
        }
        public WCF_Delegate(int? employeeId, string employeeName, string status)
        {

            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.status = status;
        }

        public WCF_Delegate(string employeeName,string fromDate,string toDate,string reason, string status)
        {  
            this.employeeName = employeeName;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.reason = reason;
            this.status = status;
        }

        public WCF_Delegate(int delegationId,string employeeName, string fromDate, string toDate, string reason, string status)
        {
            this.delegationId = delegationId;
            this.employeeName = employeeName;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.reason = reason;
            this.status = status;
        }
        [DataMember]
        public int DelegationId
        {
            get { return delegationId; }
            set { delegationId = value; }
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
        public string FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        [DataMember]
        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }
    
//CreateRequisition

    [DataContract]
    public class WCF_createRequisition
    {
        public string employeeId;
        public string  departmentCode;
        public string itemCode;
        public string  qtyNeeded;

        public WCF_createRequisition(string employeeId, string departmentCode, string itemCode, string qtyNeeded)
        {

            this.employeeId = employeeId;
            this.departmentCode = departmentCode;
            this.itemCode = itemCode;
            this.qtyNeeded = qtyNeeded;
        }

        
        [DataMember]
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string QtyNeeded
        {
            get { return qtyNeeded; }
            set { qtyNeeded = value; }
        }


    }



    [DataContract]
    public class WCF_ChangeRetrival
    {
        public string itemCode;
        public string departmentCode;
        public int retrievalId;
        public int actualQuantity;
        public int adjustmentQuantity;
        public string type;
        public string reason;
        public int userId;


        public WCF_ChangeRetrival(string itemCode, string departmentCode, int retrievalId, int actualQuantity, int adjustmentQuantity, string type, string reason, int userId)
        {

            this.itemCode = itemCode;
            this.departmentCode = departmentCode;
            this.retrievalId = retrievalId;
            this.actualQuantity = actualQuantity;
            this.adjustmentQuantity = adjustmentQuantity;
            this.type = type;
            this.reason = reason;
            this.userId = userId;
        }


        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        [DataMember]
        public int RetrievalId
        {
            get { return retrievalId; }
            set { retrievalId = value; }
        }

        [DataMember]
        public int ActualQuantity
        {
            get { return actualQuantity; }
            set { actualQuantity = value; }
        }

        [DataMember]
        public int AdjustmentQuantity
        {
            get { return adjustmentQuantity; }
            set { adjustmentQuantity = value; }
        }


        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }

        [DataContract]
        public class WCF_CurrentDelegate
        {
            public int employeeId;
            public string employeeName;
            public string status;


            public WCF_CurrentDelegate(int employeeId, string employeeName, string status)
            {

                this.employeeId = employeeId;
                this.employeeName = employeeName;
                this.status = status;
            }

            [DataMember]
            public int EmployeeId
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
            public string Status
            {
                get { return status; }
                set { status = value; }
            }


        

    }

//Change Disbursement

        [DataContract]
        public class WCF_ChangeDisbursement
        {
            public string itemDescription;
            public string departmentCode;
            public int disbursementId;
            public int receivedQuantity;
            public int adjustmentQuantity;
            public string type;
            public string reason;
            public string userId;


            public WCF_ChangeDisbursement(string itemDescription, string departmentCode, int disbursementId, int receivedQuantity, int adjustmentQuantity, string type, string reason, string userId)
            {

                this.itemDescription = itemDescription;
                this.departmentCode = departmentCode;
                this.disbursementId = disbursementId;
                this.receivedQuantity = receivedQuantity;
                this.adjustmentQuantity = adjustmentQuantity;
                this.type = type;
                this.reason = reason;
                this.userId = userId;
            }


            [DataMember]
            public string ItemDescription
            {
                get { return itemDescription; }
                set { itemDescription = value; }
            }

            [DataMember]
            public string DepartmentCode
            {
                get { return departmentCode; }
                set { departmentCode = value; }
            }

            [DataMember]
            public int DisbursementId
            {
                get { return disbursementId; }
                set { disbursementId = value; }
            }

            [DataMember]
            public int ReceivedQuantity
            {
                get { return receivedQuantity; }
                set { receivedQuantity = value; }
            }

            [DataMember]
            public int AdjustmentQuantity
            {
                get { return adjustmentQuantity; }
                set { adjustmentQuantity = value; }
            }


            [DataMember]
            public string Type
            {
                get { return type; }
                set { type = value; }
            }

            [DataMember]
            public string Reason
            {
                get { return reason; }
                set { reason = value; }
            }

            [DataMember]
            public string UserId
            {
                get { return userId; }
                set { userId = value; }
            }
        }

