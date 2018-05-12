using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ShortageManager.model;
using ShortageManager.contract;
using System.Collections.Generic;

namespace ShortageManager.model
{
    class Shortage : AbstractDAO
    {
        private const String SHORTAGE = "shortage";
        private const String SHORTAGE_ID = "shortage_id";
        private const String DATE = "date";
        private const String TIMELINE = "timeline";
        private const String PRODUCT_CD = "product_cd";
        private const String QUANTITY = "quantity";

        // 結合のための定数 from Main_Category
        private const String MAIN_CATEGORY = "main_category";
        private const String MAIN_CATE_NM = "main_cate_nm";

        // 結合のための定数 from Sub_Category
        private const String SUB_CATEGORY = "sub_category";
        private const String SUB_CATE_NM = "sub_cate_nm";

        // 結合のための定数 from product
        private const String PRODUCT = "product";
        private const String PRODUCT_NM = "product_nm";
        private const String MAIN_CATE_ID = "main_cate_id";
        private const String SUB_CATE_ID = "sub_cate_id";



        /**
         * 条件によるデータベース検索 （欠品数　降順）
         * @state   term       { firstDate, lastDate }
         * @state   conditions { mainCategory, jan, productName }
         * 
         * @return  Dictionary<string, string[]>
         *          string {"JAN"}
         *          string[] { main_cate_nm, sub_cate_nm, product_cd, product_nm, sum(quantity) }
         */
        public static IDictionary<String, String[]> selectForShortage ( DBConnection db, String[] term, String[] conditions )
        {
            String sql = "SELECT " + MAIN_CATE_NM + " \'主部門\', " + SUB_CATE_NM + " \'副部門\', " + SHORTAGE + "." + PRODUCT_CD + " \'JAN\', " + PRODUCT_NM + " \'商品名\', SUM(" + QUANTITY + ") \'欠品数\' FROM " + SHORTAGE +
                         "\r\nJOIN " + PRODUCT + " ON " + SHORTAGE + "." + PRODUCT_CD + " = " + PRODUCT + "." + PRODUCT_CD +
                         "\r\nJOIN " + SUB_CATEGORY + " ON " + PRODUCT + "." + SUB_CATE_ID + " = " + SUB_CATEGORY + "." + SUB_CATE_ID +
                         "\r\nJOIN " + MAIN_CATEGORY + " ON " + SUB_CATEGORY + "." + MAIN_CATE_ID + " = " + MAIN_CATEGORY + "." + MAIN_CATE_ID;

            String conditionOfTerm = "\r\nWHERE " + DATE + " BETWEEN " + AdjustForSQL.processingString(term[0]) + " AND " + AdjustForSQL.processingString(term[1]);

            sql += conditionOfTerm;

            if ( conditions != null )
            {
                sql += createCondition ( conditions );
            }

            sql += "\r\nGROUP BY " + SHORTAGE + "." + PRODUCT_CD +
                   "\r\nORDER BY SUM(" + QUANTITY + ") desc";

            return _select ( db, sql, conditionOfTerm );
        }

        /**
         * 検索SQLの接続
         * @return  Dictionary<string, string[]>
         *          string {"JAN"}
         *          string[] { main_cate_nm, sub_cate_nm, product_cd, product_nm, sum(quantity) }
         */
         private static IDictionary<String, String[]> _select ( DBConnection db, String sql, String conditionForCount )
        {
            Dictionary<String, String[]> shortageData = new Dictionary<String, String[]>();

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

                while ( rd.Read() )
                {
                    String jan = rd["JAN"].ToString();

                    int num_of_days = dateCount ( 
                        db,
                        conditionForCount + "\r\nAND product_cd = " + AdjustForSQL.processingString( jan )
                    );

                    String[] data = { rd["主部門"].ToString(), rd["副部門"].ToString(), jan, rd["商品名"].ToString(), rd["欠品数"].ToString() };

                    shortageData.Add ( jan, data );
                }

                Console.WriteLine ( shortageData.Count );

                return shortageData;

            } catch ( SqlException e )
            {
             return null;   
            } finally
            {
                rd.Close();
                con.Close();
            }
        }

        /**
         * 商品別の欠品日数のカウント
         */
        private static int dateCount ( DBConnection db, String condition )
        {
            String sql = "SELECT date, product_cd FROM shortage" + condition +
                         "\r\nGROUP BY date";

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
                int count = 0;
                while ( rd.Read() )
                {
                    Console.WriteLine ( rd["date"].ToString() + rd["product_cd"].ToString() );
                    count++;
                }

                return count;

            } catch ( SqlException e )
            {
                return 0;
            } finally
            {
                rd.Close();
                con.Close();
            }
        }









        /**
         * 条件文の作成
         * @state   conditions { mainCategory, jan, productName }
         */
        private static String createCondition ( String[]  conditions )
        {
            String condition = "";

            for (int i = 0; i < conditions.Length; i++)
            {
                if (conditions[i] != null)
                {
                    condition = "\r\nAND ";
                    switch ( i )
                    {
                        case 0:
                            condition += "main_cate_id = " + AdjustForSQL.processingString( conditions[i] );
                            break;
                        case 1:
                            condition += "product_cd = " + AdjustForSQL.processingString( conditions[i] );
                            break;
                        case 2:
                            condition += PRODUCT_NM + " = " + AdjustForSQL.processingString( conditions[i] );
                            break;
                    }
                }
            }

            return condition;
        }

        /*
         * List内データ
         * string[] { date, timeline, product_cd, quantity }
         */
        public static void InsertShortageData( DBConnection db, List<String[]> list)
        {
            String insert_sql = "INSERT INTO " + SHORTAGE + "VALUES\r\n";

            foreach ( String[] data in list )
            {
                insert_sql += "( " + IdManager.getNextId( db, SHORTAGE ) +
                              ", " + data[0] + ", " + data[1] + ", " + data[2] + ", " + data[3] + " )\r\n";
            }

            executeUpdate( db, insert_sql );
        }

        // 商品文字列から数量を取り出す
        public static int extractQuantity(String line)
        {
            line = line.Trim();
            int leftParenthesis = line.LastIndexOf('(');
            int length = line.LastIndexOf(')') - leftParenthesis - 1;

            String quantity = line.Substring(
                leftParenthesis + 1,
                length);

            Console.WriteLine(quantity);
            return int.Parse(quantity);
        }

    }
}
