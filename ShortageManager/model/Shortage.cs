using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ShortageManager.model;

namespace ShortageManager.model
{
    class Shortage : AbstractDBAction
    {
        private SqlConnection con;
        private SqlCommand command;
        private SqlDataReader reader;


        /*
         * List内データ
         * string[] { date, timeline, product_cd, quantity }
         */
        public void InsertShortageData(List<string[]> list)
        {
            int row_num = list.Count;
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
