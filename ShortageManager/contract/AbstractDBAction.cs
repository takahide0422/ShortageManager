using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShortageManager.contract
{
    abstract class AbstractDBAction : DBConnection
    {
        private const String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                                @"AttachDbFilename=|DataDirectory|\ShortageDatabase.mdf;" +
                                                "Integrated Security = True;" +
                                                "Connect Timeout = 30";

        private String errorMessage;


        // DBConnectionクラスから
        public SqlConnection getConnection()
        {
            return new SqlConnection(conString);
        }


        public void displayError ( Exception e )
        {
            Console.WriteLine ( e.StackTrace );
            displayError ( e.GetType().FullName + "が発生しました。\r\n" +
                           e.Source + " : " + e.TargetSite );
        }

        public void displayError ( String errorMessage )
        {
            Console.WriteLine ( errorMessage );
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
