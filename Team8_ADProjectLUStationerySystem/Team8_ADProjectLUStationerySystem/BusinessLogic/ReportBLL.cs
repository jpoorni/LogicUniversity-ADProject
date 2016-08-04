using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class ReportBLL
    {
        //createObject of DAO
        ReportDAO reportdao = new ReportDAO();
        ItemBLL itemlogic = new ItemBLL();
        OrderBLL orderlogic = new OrderBLL();

        public List<catelogueItem> GetAllItem()
        {
            List<string> slist = reportdao.getAllItemCode();
            List<catelogueItem> itemlist = new List<catelogueItem>();
            for (int i = 0; i < slist.Count; i++)
            {
                catelogueItem item = itemlogic.getItem(slist[i]);
                itemlist.Add(item);
            }

            return itemlist;

        }
        public dynamic getAllDepartment()
        {
            return reportdao.getAllDepartment();
        }
    }
}