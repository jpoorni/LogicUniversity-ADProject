using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class CategoryDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();
        public List<category> getAllCategory()
        {
            return context.categories.ToList();
        }
        public string getCatName(int catNo)
        {
            return context.categories.Where(x =>
                x.categoryId == catNo).First().categoryName;
        }

        public List<catelogueItem> getAllItem()
        {
            var list = from item in context.catelogueItems select item;
            return list.ToList();
        }

        internal List<catelogueItem> getAllItembycategory(string cateName)
        {
            var list = from ca in context.catelogueItems
                       from c in context.categories
                       where ca.categoryId == c.categoryId
                       where c.categoryName == cateName
                       select ca;
            return list.ToList();

        }
    }
}