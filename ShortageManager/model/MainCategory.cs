using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShortageManager.contract;


namespace ShortageManager.model
{
    class MainCategory : AbstractDAO
    {
        private const String MAIN_CATEGORY = "main_category";
        private const String MAIN_CATE_ID = "main_cate_id";
        private const String MAIN_CATE_NM = "main_cate_nm";

        public static String Main_category { get; }
        public static String Main_cate_id { get; }
        public static String Main_cate_nm { get; }


        /**
         *  MainCategoryデータの取得
         *  @return IList<String[]>
         *      String[] { main_cate_id, main_cate_nm }
         */
        public IList<String[]> getMainCategoryData ( DBConnection db )
        {
            String sql = "SELECT " + MAIN_CATE_ID + ", " + MAIN_CATE_NM + " FROM " + MAIN_CATEGORY;

            return _select(db, sql);
        }


        /**
         *  MainCategoryデータの取得
         *  @return IList<String[]>
         *      String[] { main_cate_id, main_cate_nm }
         */
        private IList<String[]> _select(DBConnection db, String sql)
        {
            SqlConnection con = db.getConnection();
            SqlDataReader rd = null;
            SqlCommand command = new SqlCommand()
            {
                Connection = con,
                CommandText = sql
            };

            List < String[] > dataList = new List < String[] >();

            try
            {
                con.Open();
                rd = command.ExecuteReader();

                while ( rd.Read() )
                {
                    String[] data = { rd[MAIN_CATE_ID].ToString(), rd[MAIN_CATE_NM].ToString() };
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
