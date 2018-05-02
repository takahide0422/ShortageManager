using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ShortageManager.model;
using ShortageManager.contract;

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


        
        /**
         * 条件によるデータベース検索
         * @state   conditions { firstDate, lastDate, mainCategory, jan, productName }
         */
        public static void selectForShortage ( DBConnection db, String[] conditions )
        {

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

            Console.WriteLine ( "送信するSQL文 : " + insert_sql );

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
