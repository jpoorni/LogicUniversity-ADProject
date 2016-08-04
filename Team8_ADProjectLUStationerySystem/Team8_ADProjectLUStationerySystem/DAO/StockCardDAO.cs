using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class StockCardDAO
    {
        logicUniversityEntities lue = new logicUniversityEntities();

        public List<stockCard> getStockCard(string id)
        {
            return lue.stockCards.Where(x =>
            x.itemCode == id).ToList();
        }

        public stockCard getAvailability(string id)
        {
            return lue.stockCards.Where(s => s.itemCode == id).First();
        }

        public List<string> getItemCode()
        {
            List<string> itemcode = new List<string>();
            List<stockCard> sc = lue.stockCards.ToList();
            foreach (stockCard s in sc)
            {
                itemcode.Add(s.itemCode);
               
            }
            return itemcode;
        }
    }
}