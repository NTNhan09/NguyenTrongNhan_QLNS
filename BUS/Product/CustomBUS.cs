using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Product;
using Model.Product;

namespace BUS.Product
{
    public class CustomBUS
    {
        CustomDAL dal = new CustomDAL();
        public List<CustomBEL> ReadCustomer()
        {
            List<CustomBEL> IstCus = dal.ReadCustomer();
            return IstCus;
        }
        public void NewCustomer(CustomBEL cus)
        {
            dal.NewCustomer(cus);

        }
        public void DeleteCustomer(CustomBEL cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(CustomBEL cus)
        {
            dal.EditCustomer(cus);
        }
    }
}
