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
    public class CompanyDAL
    {
        static string conString = ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;

        public static List<Company> getAllCompanies()
        {
            List<Company> list = new List<Company>();

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM COMPANY";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;

                foreach (DataRow row in rows)
                {
                    Company p1 = new Company();
                    p1.CompanyId= int.Parse(row[0].ToString());
                    p1.CompanyName = row[1].ToString();
                    
                    p1.CompanyContactNo = (row[2].ToString());
                    p1.CompanyProduct = (row[3].ToString());

                    list.Add(p1);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return list;
        }

        public static Company GetByCompanyId(int id)
        {
            Company p1 = null;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM COMPANY where id=" + id;

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRowCollection rows = tbl.Rows;
                DataRow row = rows[0];

                p1 = new Company();
                p1.CompanyId = int.Parse(row[0].ToString());
                p1.CompanyName = row[1].ToString();
                p1.CompanyContactNo = row[2].ToString(); 
                p1.CompanyProduct = row[3].ToString();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return p1;
        }

        public static bool DeleteByCompanyId(int id)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM COMPANY where id=" + id;

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

        public static bool InsertCompany(Company prod)
        {
            bool status = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM COMPANY";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataRow newRow = tbl.NewRow();
                newRow["id"] = prod.CompanyId;
                newRow["name"] = prod.CompanyName;
                newRow["contact"] = prod.CompanyContactNo;
                newRow["product"] = prod.CompanyProduct;

                DataRowCollection rows = tbl.Rows;
                rows.Add(newRow);

                ad.Update(ds);
                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return status;
        }

        public static bool UpdateCompany(Company p)
        {
            bool status = false;

            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM COMPANY";

                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                DataTable tbl = ds.Tables[0];
                DataColumn[] col = new DataColumn[1];
                col[0] = tbl.Columns["id"];
                tbl.PrimaryKey = col;

                DataRowCollection rows = tbl.Rows;
                DataRow row = rows.Find(p.CompanyId);

                row[1] = p.CompanyName;
                row[2] = p.CompanyContactNo;
                row[3] = p.CompanyProduct;

                ad.Update(ds);

                status = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return status;
        }
    }
}
