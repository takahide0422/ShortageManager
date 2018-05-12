using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShortageManager.contract
{
    class AdjustForSQL
    {
        const char SINGLE_QUATATION = '\'';

        public static String processingString ( String word )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append ( SINGLE_QUATATION );

            for ( int i = 0; i < word.Length; i++ )
            {
                char c = word[i];

                sb.Append ( c );

                if ( c == SINGLE_QUATATION )
                {
                    sb.Append ( SINGLE_QUATATION );
                }
            }
            
            sb.Append ( SINGLE_QUATATION );

            Console.WriteLine ( sb.ToString() );

            return sb.ToString();
        }
    }
}