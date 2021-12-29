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
    public class AreaDAL : DBConnection
    {
        public List<AreaBEL> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select *from congno", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<AreaBEL> IstArea = new List<AreaBEL>();
            while (reader.Read())
            {
                AreaBEL area = new AreaBEL();

                area.IdE = reader["IdEmployee"].ToString();
                area.Name = reader["Name"].ToString();
                area.Db = DateTime.Now;
                area.Gd = reader["Gender"].ToString();
                area.Pb = reader["PlaceBirth"].ToString();
                area.IdD = reader["IdDepartment"].ToString();
                IstArea.Add(area);
            }
            conn.Close();
            return IstArea;
        }
        public AreaBEL ReadArea(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select *from congno where id=" + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            AreaBEL area = new AreaBEL();
            if (reader.HasRows && reader.Read())
            {
                area.Id = reader["makhachhang"].ToString();
                area.Name = reader["tenkhachhang"].ToString();
                area.PhoneNumber = reader["sodienthoai"].ToString();
                area.AmountOwed = decimal.Parse(reader["sotienno"].ToString());
            }
            conn.Close();
            return area;
        }
    }
}
