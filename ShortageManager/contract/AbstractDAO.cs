using System;
using System.Data.SqlClient;

namespace ShortageManager.contract
{
    class AbstractDAO
    {
        // SQL更新用メソッド
        public static int executeUpdate ( DBConnection db, String sql)
        {
            SqlConnection con = db.getConnection();

            SqlCommand command = new SqlCommand ()
            {
                Connection = con,
                CommandText = sql
            };

            try
            {
                con.Open();

                int updated_num = command.ExecuteNonQuery();

                Console.WriteLine ( "更新完了ROW数 : " + updated_num );

                return updated_num;
            }
            catch (SqlException e)
            {
                Console.WriteLine ( "更新できませんでした。" );
                return 0;
            }
            finally
            {
                if (con != null)
                {
                    try
                    {
                        con.Close();
                    }
                    catch (SqlException e) { }
                }
            }
        }
    }
}
