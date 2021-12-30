using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Product;
using Model.Product;
using DAL.Product;

namespace GUI.QLNS
{
    public partial class GUI : Form
    {
        CustomBUS cusBUS = new CustomBUS();
        AreaBUS areBUS = new AreaBUS();
        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvHR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<CustomBEL> IstCus = cusBUS.ReadCustomer();
            foreach (CustomBEL cus in IstCus)
            {
                dgvHR.Rows.Add(cus.IdE, cus.Name, cus.Db,cus.Gd,cus.Pb,cus.IdD);
            }
            List<AreaBEL> IstArea = areBUS.ReadAreaList();
        }

        private void dgvHR_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvHR.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbIdE.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbDb.Text = row.Cells[2].Value.ToString();
                tbPb.Text = row.Cells[3].Value.ToString();
                CbSex.Text = row.Cells[4].Value.ToString();
                tbIdD.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btNew(object sender, EventArgs e)
        {
            CustomBEL cus = new CustomBEL();
            cus.IdE = tbIdE.Text;
            cus.Name = tbName.Text;
            cus.Db = DateTime.Parse(tbDb.Text);
            cus.Gd = bool.Parse(CbSex.Text);
            cus.Pb = tbPb.Text;
            cus.IdD = tbIdD.Text;
            cusBUS.NewCustomer(cus);

            dgvHR.Rows.Add(cus.IdE, cus.Name, cus.Db, cus.Gd, cus.Pb, cus.IdD);
        }

        private void btDelete(object sender, EventArgs e)
        {
            CustomBEL cus = new CustomBEL();
            cus.IdE = tbIdE.Text;
            cus.Name = tbName.Text;
            cus.Db = DateTime.Parse(tbDb.Text);
            cus.Gd = bool.Parse(CbSex.Text);
            cus.Pb = tbPb.Text;
            cus.IdD = tbIdD.Text;

            cusBUS.DeleteCustomer(cus);

            int idx = dgvHR.CurrentCell.RowIndex;
            dgvHR.Rows.RemoveAt(idx);
        }

        private void btEdit(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvHR.CurrentRow;
            if (row != null)
            {
                CustomBEL cus = new CustomBEL();
                cus.IdE = tbIdE.Text;
                cus.Name = tbName.Text;
                cus.Db = DateTime.Parse(tbDb.Text);
                cus.Gd = bool.Parse(CbSex.Text);
                cus.Pb = tbPb.Text;
                cus.IdD = tbIdD.Text;
                cusBUS.EditCustomer(cus);

                int idx = dgvHR.CurrentCell.RowIndex;

                dgvHR.Rows[idx].Cells[0].Value = cus.IdE;
                dgvHR.Rows[idx].Cells[1].Value = cus.Name;
                dgvHR.Rows[idx].Cells[2].Value = cus.Db;
                dgvHR.Rows[idx].Cells[3].Value = cus.Pb;
                dgvHR.Rows[idx].Cells[4].Value = cus.Gd;
                dgvHR.Rows[idx].Cells[5].Value = cus.IdD;

            }
        }

        private void btExit(object sender, EventArgs e)
        {

        }
    }
}
