using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class ItemDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();
        
        public List<catelogueItem> getAllItem()
        {
            return context.catelogueItems.ToList();
        }
        public List<catelogueItem> getAllItemByCategory(int categoryid)
        {
            return context.catelogueItems.Where(c => c.categoryId == categoryid).ToList();
        }
        public catelogueItem getItem(string itemcode)
        {
            return context.catelogueItems.Where(c => c.itemCode == itemcode).First();
        }
        public string getItemCode(string itemdescription)
        {
            var q = from i in context.catelogueItems
                    where i.itemDescription == itemdescription
                    select (new { i.itemCode });
            return q.ToString();
        }
        public List<catelogueItem> getAllItemsByItemName(string itemname)
        {
            return context.catelogueItems.Where(c => c.itemDescription == itemname).ToList();
        }
        public List<catelogueItem> getAllItemListByCategory(string categoryname)
        {
            var list1 = (from i in context.categories
                         join x in context.catelogueItems on i.categoryId equals x.categoryId
                         where i.categoryName == categoryname
                         select x).ToList();
            return list1;
        }
        public List<catelogueItem> getAllItemNameByCategory(string categoryname)
        {
            var y = (from i in context.categories
                     join x in context.catelogueItems on i.categoryId equals x.categoryId
                     where i.categoryName == categoryname
                     select x).ToList();
            return y;
        }

        public void UpdateItem(catelogueItem item)
        {
            catelogueItem UpdateItem = context.catelogueItems.Where(x =>
                x.itemCode == item.itemCode).First();

            UpdateItem.itemDescription = item.itemDescription;
            UpdateItem.reorderLevel = item.reorderLevel;
            UpdateItem.reorderQuantity = item.reorderQuantity;
            UpdateItem.uom = item.uom;
            UpdateItem.tenderPrice = item.tenderPrice;
            UpdateItem.bin = item.bin;
            context.SaveChanges();
        }

        public double? getPrice(string itemcode)
        {
            return context.catelogueItems.Where(c => c.itemCode == itemcode).First().tenderPrice;
        }


        ///Stack
        ///
        public void updateStockCardAndCatelogueItem(int poid)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            List<purchaseDetail> list = luSSEntity.purchaseDetails.Where(PD => PD.purchaseOrderno == poid).ToList();
            foreach (purchaseDetail d in list)
            {
                stockCard newtransaction = new stockCard();
                newtransaction.itemCode = d.itemCode;
                newtransaction.transactionDate = DateTime.Now;
                newtransaction.transactionType = "Supplier Order-Delivery" + " (" + d.purchaseOrder.supplier.supplierName + ")";
                newtransaction.quantity = d.receivedQuantity;
                newtransaction.balance = d.catelogueItem.quantity + d.receivedQuantity;
                luSSEntity.stockCards.Add(newtransaction);

                //update catelogueItems quantity 
                luSSEntity.catelogueItems.Where(c => c.itemCode == d.itemCode).First().quantity += d.receivedQuantity;
            }
            luSSEntity.SaveChanges();
        }


        
    }
}