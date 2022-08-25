using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class Baglanti
    {

        public static OleDbConnection bag = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Kütüphane.accdb");

    }
}
