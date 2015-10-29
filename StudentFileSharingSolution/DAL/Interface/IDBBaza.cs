using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DAL.Interface
{
    /*
     * Interfejs za setiranje na Konekcii i objekti
     * za komunikacija so bazata.  
     */
    interface IDBBaza
    {
        /*
         * KonekcijaString/ConnectionString vraka formatiran string za
         * povrzuvanje so bazata, koj e procitan od web.config.
         * Pri greska podiga greska(exception) -
         * (KonekcijaString ne e definiran vo web.config)
         */
        String KonekcijaString
        {
            get;
        }
        String ConnectionString
        {
            get;
        }

         /*
          * VratiKoneckija() e fuc. koja vraka SqlConn. obj
          * koj e definiran so KonekcijaString procitan od
          * web.config.
         */

        SqlConnection  vratiKonekcija();
       
        /*
         * VratiKoneckijaSoTest() e fuc. koja vraka SqlConn. obj
         * koj e definiran so KonekcijaString procitan od
         * web.config i pritoa ja testira konekcijata. Pri greska
         * podiga greska(exception) - 
         * (Problem so komunikacija so bazata)
        */

        SqlConnection vratiKonekcijaSoTest();
        
        /*
         * proveriKonekcija() proveruva dali tekovnata konekcija moze da 
         * vospostavi komunikacija so bazata i 
         * pritoa ja testira konekcijata. Pri greska podiga greska(exception) - 
         * (Problem so komunikacija so bazata)
         */

         bool proveriKonekcija(SqlConnection sqlCn);

        /*
         * Rabota so Store proceduri i nivno izvrsuvanje!
         */

         int ExecuteNonQuery(Array paramArray, String imeSP,[Optional] SqlConnection sqlCn);
         object ExecuteScalar(Array paramArray, String imeSP, [Optional] SqlConnection sqlCn);
         SqlDataReader ExecuteReader(Array paramArray, String imeSP, [Optional] SqlConnection sqlCn);
         DataSet GetDataSet(Array paramArray, String imeSP, [Optional] SqlConnection sqlCn);
    }
}
