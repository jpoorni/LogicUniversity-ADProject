using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class ItemBLL
    {
        ItemDAO itemDAO = new ItemDAO();
        public List<catelogueItem> getAllItem()
        {
            return itemDAO.getAllItem();
        }
        public List<catelogueItem> getAllItemByCategory(int categoryid)
        {
            return itemDAO.getAllItemByCategory(categoryid);
        }
        public catelogueItem getItem(string itemcode)
        {
            return itemDAO.getItem(itemcode);
        }
        public string getItemCode(string itemdescription)
        {
            return itemDAO.getItemCode(itemdescription);
        }

        public List<catelogueItem> getAllItemNameByCategory(string category)
        {
            return itemDAO.getAllItemNameByCategory(category);
        }

        public List<catelogueItem> itemListbyCat(string categoryname)
        {
            return itemDAO.getAllItemListByCategory(categoryname);
        }

        public List<catelogueItem> itemListByItemName(string itemname)
        {
            return itemDAO.getAllItemsByItemName(itemname);
        }

        public void UpdateItem(string itemCode,string bin, string des, string rl, string rqty, string uom, string tp)
        {
            
            catelogueItem newItem = new catelogueItem();
            newItem.itemCode = itemCode;
            newItem.itemDescription = des;
            newItem.reorderLevel = Convert.ToInt32(rl);
            newItem.reorderQuantity = Convert.ToInt32(rqty);
            newItem.uom = uom;
            newItem.tenderPrice = Convert.ToDouble(tp);
            newItem.bin = bin;
            //in web: string photo=Convert.ToBoolean(FileUpload1.HasFile).ToString();
            itemDAO.UpdateItem(newItem);
        }

        public double? getPrice(string itemcode)
        {
            return itemDAO.getPrice(itemcode);
        }


        //Stack

        public void updateStockCardAndCatelogueItem(int poid)
        {
            itemDAO.updateStockCardAndCatelogueItem(poid);
        }

    }
}