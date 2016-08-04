using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class StockCard
    {
        DAO.StockCardDAO stockcardDAO = new DAO.StockCardDAO();
        public List<stockCard> getStockCard(string id)
        {
            return stockcardDAO.getStockCard(id);
        }

        public stockCard getAvailability(string id)
        {
            return stockcardDAO.getAvailability( id);
        }

        public List<string> getItemCodeList()
        {
            return stockcardDAO.getItemCode();
        }

    }
}