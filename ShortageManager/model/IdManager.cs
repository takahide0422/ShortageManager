using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShortageManager.contract;

namespace ShortageManager.model
{
    class IdManager : AbstractDAO
    {
        private const String ID_MANAGER = "id_manager";
        private const String ID = "id";
        private const String ID_NAME = "id_name";
        private const String NEXT_ID = "next_id";


        // id_nameに対応した next_idの取得
        public static String getNextId ( DBConnection db, String id_name )
        {
            String sql = "SELECT " + NEXT_ID + " FROM " + ID_MANAGER +
                "\r\nWHERE " + ID_NAME + " = " + id_name;

            SqlConnection con = db.getConnection();
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

                while (rd.Read())
                {
                    String next_id = rd[NEXT_ID].ToString();
                    updateNextId ( db, id_name, next_id );

                    return next_id;
                }

                Console.WriteLine ( "IDが見つかりませんでした。" );

                return null;
            } catch {
                Console.WriteLine ( "IDを取得できませんでした。" );
                return null;
            } finally
            {
                rd.Close();
                con.Close();
            }
        }

        // next_idカラムの更新
        private static void updateNextId ( DBConnection db, String id_name, String id )
        {
            String sql = "UPDATE " + ID_MANAGER + " SET " + NEXT_ID + " = " + nextId ( id ) +
                "\r\nWHERE " + ID_NAME + " = " + id_name;

            executeUpdate ( db, sql );
        }

        // next_idの生成
        private static String nextId ( String id )
        {
            char c = id[0];
            
            String id_num = id.Substring ( 1, 5 );
            if (id_num != "99999")
            {
                int num = int.Parse ( id_num );
                id_num = num++.ToString( "00000" );
            } else
            {
                id_num = "00000";
                if (c != 'Z')
                {
                    int ascii = (int)c;
                    c = (char)ascii++;
                }
            }

            return  c + id_num;
        }
    }
}
