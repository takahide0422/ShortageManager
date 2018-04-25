using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortageManager.model
{
    class DBConnection
    {
        protected const String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                            @"AttachDbFilename=|DataDirectory|\ShortageDatabase.mdf;" +
                                            "Integrated Security = True; Connect Timeout = 30";
    }
}
