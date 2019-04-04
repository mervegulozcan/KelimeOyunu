using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
/*
 * 
 * */

namespace KelimeOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PI6M05P\MSSQLSRV;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand =new SqlCommand("Select case when CHARINDEX(' ',ProductName)>0 Then LEFT(ProductName, CHARINDEX(' ', ProductName) - 1) else ProductName END FROM PRODUCTS", con);
            /*
             * Charindex'le productName içinde boşluk kaçıncı indexteyse onu döndürür.
             * Left ile ProductName'de boşluktan önceki(Sol tarafını) alıcak.
             * Else durumunda ise Charindexte birşey bulamadıysa (boşluk bulamadıysa) direk kelimeyi yazdırır.

             * */
            DataTable dt = new DataTable();
            adp.Fill(dt);
            while (1==1)
            { 
                Console.Write("Lütfen harf giriniz: ");
                string alınanKelime = Console.ReadLine().ToUpper();

                bool sart = true;
                int tabloSayac = 0, kelimeSayac = 0;
                string tablodegeri,alınanHarf;
                alınanHarf = alınanKelime.Substring(0, 1);
                do
                {
                        tablodegeri = dt.Rows[tabloSayac][0].ToString();

                        if (tablodegeri.Substring(0, 1).ToUpper() == alınanHarf)
                        //Substring(0,1) 0.harften başlayıp ilk harfi alır.
                        {
                            Console.WriteLine(tablodegeri);
                            alınanHarf = tablodegeri[tablodegeri.Length - 1].ToString().ToUpper();//alınan harf tablodeğerinin son harfine eşitledik.
                            dt.Rows[tabloSayac][0] = " ";
                            tabloSayac = 0;
                            kelimeSayac++;
                        }
                        
                        if (tabloSayac == dt.Rows.Count - 1)
                        {
                            sart = false;
                            Console.WriteLine("{0} kelime bulundu", kelimeSayac);
                        }
                        tabloSayac++;
                } while (sart);
            }
            
        }
    }
}
