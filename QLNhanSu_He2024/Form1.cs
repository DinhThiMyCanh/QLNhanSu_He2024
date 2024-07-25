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
        }

        private void Thoat(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Xoa(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sua(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
    }
}
