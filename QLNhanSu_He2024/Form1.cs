using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu_He2024
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnThem.Click += new EventHandler(Them);
            btnSua.Click += new EventHandler(Sua);
            btnXoa.Click += new EventHandler(Xoa);
            btnLamMoi.Click += new EventHandler(LamMoi);
            btnThoat.Click += new EventHandler(Thoat);
            btnTimNV.Click += new EventHandler(TimKiem);
        }

        private void TimKiem(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql = string.Format("Select * from DSNV where HoTen Like N'%{0}'",txtTenNV.Text);
            dataGridView1.DataSource = Data_Provider.getTable(sql);
            Data_Provider.dongKetNoi();
        }

        private void Thoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtHoTen.Focus();
            dtpNgaySinh.Value = DateTime.Now;
            if (rdNam.Checked == false)
                rdNam.Checked = true;
            txtHSL.Clear();
            txtSoDT.Clear();
            cboTenPhong.SelectedIndex = 0;
            cboTenCV.SelectedIndex = 0;
            load_DSNV();
        }

        private void Xoa(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                int ma = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                string sql = string.Format("Delete from DSNV where MaNV ='{0}'", ma);
                Data_Provider.updateData(sql);
                load_DSNV();
            }
            Data_Provider.dongKetNoi();
            
        }

        private void Sua(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            if (isNumber(txtHSL.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
            {
                string sql = string.Format("Update DSNV set HoTen =@ht, NgaySinh =@ns, GioiTinh=@gt, " +
                    "soDT=@soDT, HeSoLuong =@hsl, MaPhong =@maP,MaChucVu=@maCV " +
                    "where MaNV ='{0}'" , txtMaNV.Text);

                bool gt = rdNam.Checked == true ? true : false;
                object[] value = { txtHoTen.Text, dtpNgaySinh.Value,gt,txtSoDT.Text,
                float.Parse(txtHSL.Text),cboTenPhong.SelectedValue.ToString(),cboTenCV.SelectedValue.ToString()};
                string[] name = { "@ht", "@ns", "@gt", "@soDT", "@hsl", "@maP", "@maCV" };

                Data_Provider.updateData(sql, value, name);
                load_DSNV();
            }
            else
                MessageBox.Show("Dữ liệu không hợp lệ");
            Data_Provider.dongKetNoi();
        }

        #region Kiểm tra tính hợp lệ dữ liệu
        //Kiểm tra giá trị số
        public bool isNumber(string value)
        {
            bool ktra;
            float result;
            ktra = float.TryParse(value,out result);
            return ktra;
        }
        #endregion
        private void Them(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            //string sql1 = string.Format("Select count(*) from DSNV where MaNV ='{0}'", txtMaNV.Text);
            //if ((Data_Provider.checkData(sql1)==0) && isNumber(txtHSL.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
            //{
            //   Thêm nhân viên
            //}    

            if (isNumber(txtHSL.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
            {
                string sql = "insert into DSNV(HoTen,NgaySinh,GioiTinh,soDT,HeSoLuong,MaPhong,MaChucVu)" +
                "values(@ht,@ns,@gt,@soDT,@hsl,@maP,@maCV)";

                bool gt = rdNam.Checked == true ? true : false;
                object[] value = { txtHoTen.Text, dtpNgaySinh.Value,gt,txtSoDT.Text,
                float.Parse(txtHSL.Text),cboTenPhong.SelectedValue.ToString(),cboTenCV.SelectedValue.ToString()};
                string[] name = { "@ht", "@ns", "@gt", "@soDT", "@hsl", "@maP", "@maCV" };

                Data_Provider.updateData(sql, value, name);
                load_DSNV();
            }    
            else
                MessageBox.Show("Dữ liệu không hợp lệ");
            Data_Provider.dongKetNoi();


        }
#region Lấy dữ liêu
        public void load_PB()
        {
            string sql = "select * from DMPHONG";
            cboTenPhong.DataSource = Data_Provider.getTable(sql);
            cboTenPhong.DisplayMember = "TenPhong";
            cboTenPhong.ValueMember = "MaPhong";
        }
        public void load_CV()
        {
            string sql = "select * from CHUCVU";
            cboTenCV.DataSource = Data_Provider.getTable(sql);
            cboTenCV.DisplayMember = "TenChucVu";
            cboTenCV.ValueMember = "MaChucVu";
        }
        public void load_DSNV()
        {
            string sql = "select * from DSNV";
            dataGridView1.DataSource = Data_Provider.getTable(sql);
        }
#endregion

        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            load_PB();
            load_CV();
            load_DSNV();
            Data_Provider.dongKetNoi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            string gt = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (gt == "True")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;

            txtSoDT.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtHSL.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cboTenPhong.SelectedValue = dataGridView1.Rows[i].Cells[6].Value.ToString();
            cboTenCV.SelectedValue = dataGridView1.Rows[i].Cells[7].Value.ToString();

        }
    }
}
