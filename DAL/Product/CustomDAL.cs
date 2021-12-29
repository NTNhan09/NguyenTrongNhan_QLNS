using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Product;
using Model.Product;

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
                cus.Db = DateTime.Now["DateBirth"].ToString();
                cus.Gd = ; 
                cus.Pb = reader["PlaceBirth"].ToString();
                cus.IdD = reader["IdDepartment"].ToString();
                Istcus.Add(cus);

            }
            conn.Close();
            return Istcus;
        }
        public void insert()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString= configurationManager.
        }
        public void EditCustomer(CustomBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("undate congno set name=@tenkhachhang,PhoneNumber=@sodienthaoi, AmountOwed=@sotienno where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdE));
            cmd.Parameters.Add(new SqlParameter("@Name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.Db));
            cmd.Parameters.Add(new SqlParameter("@Gender", cus.Gd));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.Pb));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.IdD));

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCustomer(CustomBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete congno where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewCustomer(CustomBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into congno values(@makhachhang,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cus.AmountOwed));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
