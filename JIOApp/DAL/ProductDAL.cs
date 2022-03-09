using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BOL;
using System.Data;
using System.Configuration;


namespace DAL
{
    public class ProductDAL
    {
        static string conString = ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;

        public static List<Product> getAllProduct()
        {
            List<Product> list = new List<Product>();

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM PRODUCT";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;

                foreach (DataRow row in rows)
                {
                    Product p1 = new Product();
                    p1.Id = int.Parse(row[0].ToString());
                    p1.Title = row[1].ToString();
                    p1.Info = row[2].ToString();
                    p1.UnitPrice = int.Parse(row[3].ToString());
                    p1.Quantity = int.Parse(row[4].ToString());
                    list.Add(p1);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return list;
        }

        public static Product getById(int id)
        {
            Product p1 = null;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM PRODUCT where id=" + id;

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;
                DataRow row = rows[0];

                p1 = new Product();
                p1.Id = int.Parse(row[0].ToString());
                p1.Title = row[1].ToString();
                p1.Info = row[2].ToString();
                p1.UnitPrice = int.Parse(row[3].ToString());
                p1.Quantity = int.Parse(row[4].ToString());


            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return p1;
        }

        public static bool deleteById(int id)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM PRODUCT where id=" + id;

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];

                DataColumn[] col = new DataColumn[1];
                col[0] = tbl.Columns["Id"];
                tbl.PrimaryKey = col;


                DataRowCollection rows = tbl.Rows;
                DataRow foundRow = rows.Find(id);

                foundRow.Delete();

                ad.Update(ds);

                /*  
                 //ds.Tables[0].Rows[id].Delete();

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;
                DataRow row = rows[id];
                row.Delete();*/

                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return status;
        }

        public static bool insertProduct(Product prod)
        {
            bool status = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM PRODUCT";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRow newRow = tbl.NewRow();
                newRow["Id"] = prod.Id;
                newRow["title"] = prod.Title;
                newRow["info"] = prod.Info;
                newRow["price"] = prod.UnitPrice;
                newRow["quantity"] = prod.Quantity;

                DataRowCollection rows = tbl.Rows;
                rows.Add(newRow);

                ad.Update(ds);
                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return status;
        }

        public static bool updateProduct(Product p)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM PRODUCT";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataColumn[] col = new DataColumn[1];
                col[0] = tbl.Columns["Id"];
                tbl.PrimaryKey = col;

                DataRowCollection rows = tbl.Rows;
                DataRow row = rows.Find(p.Id);

                row[1] = p.Title;
                row[2] = p.Info;
                row[3] = p.UnitPrice;
                row[4] = p.Quantity;

                ad.Update(ds);

                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return status;
        }
    }
}
