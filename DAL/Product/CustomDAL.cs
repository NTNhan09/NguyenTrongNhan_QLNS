using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Product;
using Model.Product;
using System.Data;
using System.Configuration;

namespace DAL.Product
{
    public class CustomDAL : DBConnection
    {
        public List<CustomBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from HR", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<CustomBEL> Istcus = new List<CustomBEL>();
            AreaDAL are = new AreaDAL();
            while (reader.Read())
            {
                CustomBEL cus = new CustomBEL();
                cus.IdE = reader["IdEmployee"].ToString();
                cus.Name = reader["Name"].ToString();
                cus.Db = DateTime.Parse(reader["DateBirth"].ToString());
                cus.Gd = bool.Parse(reader["Grander"].ToString()); 
                cus.Pb = reader["PlaceBirth"].ToString();
                cus.IdD = reader["IdDepartment"].ToString();
                Istcus.Add(cus);

            }
            conn.Close();
            return Istcus;
        }
        public void NewCustomer(CustomBEL cus)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "spInsertNhanSu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdE));
                cmd.Parameters.Add(new SqlParameter("@Name", cus.Name));
                cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.Db));
                cmd.Parameters.Add(new SqlParameter("@Gender", cus.Gd));
                cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.Pb));
                cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.IdD));

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Them nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }

        }


        public void EditCustomer(CustomBEL cus)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "spUpdateNhanSu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdE));
                cmd.Parameters.Add(new SqlParameter("@Name", cus.Name));
                cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.Db));
                cmd.Parameters.Add(new SqlParameter("@Gender", cus.Gd));
                cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.Pb));
                cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.IdD));

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Sua nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }

            finally
            {
                con.Close();
            }

        }

        public void DeleteCustomer(CustomBEL cus)
        {
            SqlConnection con = new SqlConnection();
            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandText = "spDeleteNhanSu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdE));

                con.Open();
                
                cmd.ExecuteNonQuery();
                
                con.Close();

                Console.WriteLine("Xoa nhan vien thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            
            finally
            {
                con.Close();
            }

        }

    }
}
