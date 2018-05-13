using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShortageManager.contract;

namespace ShortageManager.model
{
    class SubCategory
    {
        private const String SUB_CATEGORY = "sub_category";
        private const String SUB_CATE_ID = "sub_cate_id";
        private const String SUB_CATE_NM = "sub_cate_nm";
        private const String MAIN_CATE_ID = "main_cate_id";

        
        public static String Sub_category { get; }
        public static String Sub_cate_id { get; }
        public static String Sub_cate_nm { get; }
        public static String Main_cate_id { get; }

        /**
         *  SubCategoryデータの検索
         *  @return IList< String[] >
         *      String[] { main_cate_id, main_cate_nm, sub_cate_id, sub_cate_nm }
         */
         public IList < String[] > getSubCategoryData ( DBConnection db )
        {
            String sql = "SELECT " + MainCategory.Main_cate_id + MainCategory.Main_cate_nm + Sub_cate_id + Sub_cate_nm + " FROM " + Sub_category +
                         "\r\nJOIN " + MainCategory.Main_category +
                         "\r\nON " + Sub_category + "." + Main_cate_id + " = " + MainCategory.Main_category + "." + MainCategory.Main_cate_id +
                         "\r\nORDER BY " + MainCategory.Main_category + "." + MainCategory.Main_cate_id + " ASC";

            return _select ( db, sql );
        }

        /**
         *  SubCategoryデータの検索
         *  @return IList< String[] >
         *      String[] { main_cate_id, main_cate_nm, sub_cate_id, sub_cate_nm }
         */
         private IList < String[] > _select ( DBConnection db, String sql )
        {
            SqlConnection con = db.getConnection();
            SqlDataReader rd = null;
            SqlCommand command = new SqlCommand ()
            {
                Connection = con,
                CommandText = sql
            };

            List < String[] > dataList = new List < String[] > ();

            try
            {
                con.Open();
                rd = command.ExecuteReader();

                while ( rd.Read() )
                {
                    String[] data = { rd [ MainCategory.Main_cate_id ].ToString(), rd [ MainCategory.Main_cate_nm ].ToString(),
                                      rd [ Sub_cate_id ].ToString(), rd [ Sub_cate_nm ].ToString() };
                    dataList.Add ( data );
                }

                return dataList;

            } catch ( SqlException e )
            {
                Console.WriteLine ( e.StackTrace );
                return null;
            } finally
            {
                rd.Close();
                con.Close();
            }
        }
    }
}
