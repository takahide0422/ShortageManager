using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortageManager.model
{
    abstract class AbstractDBConnection
    {
        protected const String T_MAIN_CATEGORY = "main_category";
        protected const String MAIN_CATE_ID;
        protected const String MAIN_CATE_NM;

        protected const String T_SUB_CATEGORY = "sub_category";
        protected const String SUB_CATE_ID;
        protected const String SUBM_CATE_NM;
        protected const String MAIN_CATE_ID;

        protected const String T_PRODUCT = "product";
        protected const String PRODUCT_CD;
        protected const String PRODUCT_NM;
        protected const String PRODUCT_PRICE;
        protected const String SUB_CATE_ID;

        protected const String T_SHORTAGE = "shortage";
        protected const String SHORTAGE_ID;
        protected const String DATE;
        protected const String TIMELINE;
        protected const String PRODUCT_CD;
        protected const String QUANTITY;
    }
}
