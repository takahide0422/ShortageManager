using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShortageManager.model
{
    abstract class AbstractDBAction
    {
        private const String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                                @"AttachDbFilename=|DataDirectory|\ShortageDatabase.mdf;" +
                                                "Integrated Security = True;" +
                                                "Connect Timeout = 30";

        private String t_main_category = "main_category";
        private String main_cate_id = "main_cate_id";
        private String main_cate_nm = "main_cate_nm";

        private String t_sub_category = "sub_category";
        private String sub_cate_id = "sub_cate_id";
        private String sub_cate_nm = "sub_cate_nm";
        // private String main_cate_id = "main_cate_id";

        private const String t_product = "product";
        private const String product_cd = "product_cd";
        private const String product_nm = "product_nm";
        private const String product_price = "product_price";
        // private String sub_cate_id = "sub_cate_id";

        private String t_shortage = "shortage";
        private String shortage_id = "shortage_id";
        private String date = "date";
        private String timeline = "timeline";
        // private String product_cd = "product_cd";
        private String quantity = "quantity";

        public String T_main_category { get; }
        public String Main_cate_id { get; }
        public String Main_cate_nm { get; }

        public String T_sub_category { get; }
        public String Sub_cate_id { get; }
        public String Sub_cate_nm { get; }

        public String T_product { get; }
        public String Product_cd { get; }
        public String Product_nm { get; }
        public String Product_price { get; }

        public String T_shortage { get; }
        public String Shortage_id { get; }
        public String Date { get; }
        public String Timeline { get; }
        public String Quantity { get; }

        private String errorMessage;


        public void displayError ( Exception e )
        {
            Console.WriteLine ( e.StackTrace );
            displayError ( e.GetType().FullName + "が発生しました。\r\n" +
                           e.Source + " : " + e.TargetSite );
        }

        public void displayError ( String errorMessage )
        {
            this.errorMessage = errorMessage;
            Console.WriteLine ( this.errorMessage );
        }

        public virtual SqlConnection getConnection ()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conString;
            return con;
        }

        // SQL更新用メソッド
        public int executeUpdate ( String sql )
        {
            SqlConnection con = null;

            SqlCommand command = null;

            try
            {
                con = new SqlConnection ( conString );
                con.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                int updated_num = command.ExecuteNonQuery();

                return updated_num;
            }
            catch ( SqlException e )
            {
                displayError ( e );
                return 0;
            }
            finally
            {
                if ( con != null )
                {
                    try {
                        con.Close();
                    }
                    catch ( SqlException e ) { }
                }
            }
        }

        // 行数取得
        public int rowNumQuery ( String table_nm )
        {
            String sql = @"SELECT count(*) as num FROM " + table_nm;

            SqlConnection con = new SqlConnection ( conString );
            SqlDataReader rd = null;
            SqlCommand command = new SqlCommand()
            {
                Connection = con,
                CommandText = sql
            };

            try
            {
                con.Open();
                rd = command.ExecuteReader();
                
                int row_num = 0;

                while ( rd.Read() )
                {
                    row_num = int.Parse ( rd["num"].ToString() );
                }
                return row_num;
            } catch ( SqlException e )
            {
                displayError ( e );
                return 0;
            } finally
            {
                rd.Close();
                con.Close();
            }
        }
    }
}
