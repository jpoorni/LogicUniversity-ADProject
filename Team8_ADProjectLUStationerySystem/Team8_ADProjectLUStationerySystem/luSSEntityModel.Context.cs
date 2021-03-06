﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team8_ADProjectLUStationerySystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class logicUniversityEntities : DbContext
    {
        public logicUniversityEntities()
            : base("name=logicUniversityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adjustment> adjustments { get; set; }
        public virtual DbSet<adjustmentDetail> adjustmentDetails { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<catelogueItem> catelogueItems { get; set; }
        public virtual DbSet<collectionPoint> collectionPoints { get; set; }
        public virtual DbSet<delegateEmployee> delegateEmployees { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<disbursement> disbursements { get; set; }
        public virtual DbSet<disbursementDetail> disbursementDetails { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<purchaseDetail> purchaseDetails { get; set; }
        public virtual DbSet<purchaseOrder> purchaseOrders { get; set; }
        public virtual DbSet<requisition> requisitions { get; set; }
        public virtual DbSet<requisitionDetail> requisitionDetails { get; set; }
        public virtual DbSet<requisitionStatu> requisitionStatus { get; set; }
        public virtual DbSet<retrieval> retrievals { get; set; }
        public virtual DbSet<retrievalDetail> retrievalDetails { get; set; }
        public virtual DbSet<retrievalRequisition> retrievalRequisitions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<stockCard> stockCards { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<userDetail> userDetails { get; set; }
        public virtual DbSet<REPORT_VIEW> REPORT_VIEW { get; set; }
        public virtual DbSet<VS_ORDER> VS_ORDER { get; set; }
    
        public virtual ObjectResult<AdjustmentListSP_Result> AdjustmentListSP(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AdjustmentListSP_Result>("AdjustmentListSP", idParameter);
        }
    
        public virtual ObjectResult<AllAdjustmentDetails_Rpt_Result> AllAdjustmentDetails_Rpt()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllAdjustmentDetails_Rpt_Result>("AllAdjustmentDetails_Rpt");
        }
    
        public virtual ObjectResult<DisbursementListSP_Result> DisbursementListSP(Nullable<int> rid)
        {
            var ridParameter = rid.HasValue ?
                new ObjectParameter("rid", rid) :
                new ObjectParameter("rid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DisbursementListSP_Result>("DisbursementListSP", ridParameter);
        }
    
        public virtual ObjectResult<RequisitionListSP_Result> RequisitionListSP(Nullable<int> reqid)
        {
            var reqidParameter = reqid.HasValue ?
                new ObjectParameter("reqid", reqid) :
                new ObjectParameter("reqid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RequisitionListSP_Result>("RequisitionListSP", reqidParameter);
        }
    
        public virtual ObjectResult<RetrievalListSP_Result> RetrievalListSP(Nullable<int> rid)
        {
            var ridParameter = rid.HasValue ?
                new ObjectParameter("rid", rid) :
                new ObjectParameter("rid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrievalListSP_Result>("RetrievalListSP", ridParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
