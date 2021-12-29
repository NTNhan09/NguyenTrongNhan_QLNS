using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Product;
using Model.Product;

namespace BUS.Product
{
    public class AreaBUS
    {
        AreaDAL dal = new AreaDAL();
        public List<AreaBEL> ReadAreaList()
        {
            List<AreaBEL> IstArea = dal.ReadAreaList();
            return IstArea;
        }
    }
}
