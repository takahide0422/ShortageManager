using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortageManager.model
{
    abstract class AbstractDBConnection
    {
        protected const String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename=|DataDirectory|\ShortageDatabase.mdf;" +
                                    "Integrated Security = True; Connect Timeout = 30";

        public String ConnectionString { get; }

        protected const String T_MAIN_CATEGORY = "main_category";
        protected const String MAIN_CATE_ID = "main_cate_id";
        protected const String MAIN_CATE_NM = "main_cate_nm";

        protected const String T_SUB_CATEGORY = "sub_category";
        protected const String SUB_CATE_ID = "sub_cate_id";
        protected const String SUB_CATE_NM = "sub_cate_nm";
        // protected const String MAIN_CATE_ID = "main_cate_id";

        protected const String T_PRODUCT = "product";
        protected const String PRODUCT_CD = "product_cd";
        protected const String PRODUCT_NM = "product_nm";
        protected const String PRODUCT_PRICE = "product_price";
        // protected const String SUB_CATE_ID = "sub_cate_id";

        protected const String T_SHORTAGE = "shortage";
        protected const String SHORTAGE_ID = "shortage_id";
        protected const String DATE = "date";
        protected const String TIMELINE = "timeline";
        // protected const String PRODUCT_CD = "product_cd";
        protected const String QUANTITY = "quantity";

        private String errorMessage = null;
        public void 
    }
}
