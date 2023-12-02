
using DemCuu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DemCuu.Forms
{
    public partial class MainForm : Form
    {
        private List<DonHang> donHangs = new List<DonHang>();

        public static DonHang currentDonHang = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDatHang_Click(object sender, System.EventArgs e)
        {
            int soLuong;
            try
            {
                var ten = txtTen.Text;
                if (string.IsNullOrWhiteSpace(ten))
                {
                    throw new Exception("Không được để trống thông tin khách hàng!");
                }

                if (Int32.TryParse(txtSoLuong.Text, out soLuong))
                {
                    if (soLuong <= 0)
                    {
                        throw new Exception("Số lượng đặt phải là số nguyên dương!");
                    }
                }
                else
                {
                    throw new Exception("Số lượng đặt không hợp lệ!");
                }

                var phone = txtSoDienThoai.Text;
                if (string.IsNullOrWhiteSpace(phone))
                {
                    throw new Exception("Vui lòng nhập số điện thoại!");
                }

                int max = 0;
                if (donHangs.Count > 0)
                {
                    max = donHangs.Max(x => x.Stt);
                }

                var newDonHang = new DonHang
                {
                    Stt = max + 1,
                    Phone = phone,
                    SoLuong = soLuong,
                    TenKhachHang = ten,
                    Status = (int)DonHangStatus.WAITING,
                    ThoiGianDat = DateTime.Now,
                    ThoiGianHoanThien = null
                };

                donHangs.Add(newDonHang);

                ListViewItem item = new ListViewItem(newDonHang.Stt.ToString());
                item.SubItems.Add(newDonHang.TenKhachHang);
                item.SubItems.Add(newDonHang.SoLuong.ToString());
                item.SubItems.Add(newDonHang.Phone);
                item.SubItems.Add(newDonHang.getStatusName);
                lvDonDatHang.Items.Add(item);

                clearInput();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {
            txtTen.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
        }

        private void btnChayDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = lvDonDatHang.CheckedItems.OfType<DonHang>().Where(o => o.Status == (int)DonHangStatus.WAITING);
                if (temp.Count() <= 0)
                {
                    throw new Exception("Không có đơn hàng nào để chạy");
                }
                else
                {
                    foreach (var item in lvDonDatHang.CheckedItems)
                    {
                        currentDonHang = (DonHang)item;
                        var processForm = new DemCuuForm();
                        lvDonDatHang.CheckedItems.OfType<DonHang>().FirstOrDefault(o => o.Stt == currentDonHang.Stt).Status = (int)DonHangStatus.IN_PROGRESS;
                        processForm.ShowDialog();
                        lvDonDatHang.CheckedItems.OfType<DonHang>().FirstOrDefault(o => o.Stt == currentDonHang.Stt).Status = (int)DonHangStatus.FINISHED;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
