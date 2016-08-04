using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class CategoryBLL
    {
        CategoryDAO categoryDAO = new CategoryDAO();
        public List<category> getAllCategory()
        {
            return categoryDAO.getAllCategory();
        }
        public string getCatName(int catNo)
        {
            return categoryDAO.getCatName(catNo);
        }

        public List<catelogueItem> getAllItem()
        {
            return categoryDAO.getAllItem();
        }

        public List<catelogueItem> getAllItembycategory(string cateName)
        {
            return categoryDAO.getAllItembycategory(cateName);
        }
    }
}