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
    public class CustomerDAL
    {
        static string conString = ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;

        public static List<Customer> GetAllCustomer()
        {
            List<Customer> list = new List<Customer>();

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Customer";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;

                foreach (DataRow row in rows)
                {
                    Customer p1 = new Customer();
                    p1.Id = int.Parse(row[0].ToString());
                    p1.FullName = row[1].ToString();
                    p1.Address = row[2].ToString();
                    p1.ContactNo = (row[3].ToString());
                    p1.Product = row[4].ToString();
                    list.Add(p1);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return list;
        }

        public static Customer GetByCustomerId(int id)
        {
            Customer p1 = null;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Customer where id=" + id;

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;
                DataRow row = rows[0];

                p1 = new Customer();
                p1.Id = int.Parse(row[0].ToString());
                p1.FullName = row[1].ToString();
                p1.Address = row[2].ToString();
                p1.ContactNo = (row[3].ToString());
                p1.Product = row[4].ToString();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return p1;
        }

        public static bool DeleteByCustomerId(int id)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Customer where id=" + id;

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

        public static bool InsertCustomer(Customer prod)
        {
            bool status = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Customer";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRow newRow = tbl.NewRow();
                newRow["id"] = prod.Id;
                newRow["name"] = prod.FullName;
                newRow["address"] = prod.Address;
                newRow["contact"] = prod.ContactNo;
                newRow["product"] = prod.Product;

                DataRowCollection rows = tbl.Rows;
                rows.Add(newRow);

                ad.Update(ds);
                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return status;
        }

        public static bool UpdateCustomer(Customer p)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Customer";

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

                row[1] = p.FullName;
                row[2] = p.Address;
                row[3] = p.ContactNo;
                row[4] = p.Product;

                ad.Update(ds);

                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return status;
        }
    }
}
