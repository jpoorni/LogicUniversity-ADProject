using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class ValidationBLL
    {
        public Boolean checkOrderValue(int value)
        {
            //all item min value is 10, max value is 500 at default
            //for PO => order quanity allows to make it triple of max value
            //min value is 9 and max value is 500 to cover every items
            if (value <= 9 || value > 1500)
            {
                return false;
            }
            else
            {
                return true;
            }
        }        
    }
}