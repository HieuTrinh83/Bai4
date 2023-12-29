
using DemCuu.Models;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DemCuu.Forms
{
    public partial class MainForm : Form
    {
        public static DonHang currentDonHang = null;
        public static int nextBarChartValue = 0;
        public static int blackSheepCounter = 0;
        public static int whiteSheepCounter = 0;
        public static int graySheepCounter = 0;

        private List<DonHang> donHangs = new List<DonHang>();
        private bool isChayDonHang = false;
        private int startMinute = 0;


        Timer chartTimer = new Timer();

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
                var temp = lvDonDatHang.CheckedItems.OfType<ListViewItem>().Select(o =>o.Text);
                if (temp.Count() <= 0)
                {
                    throw new Exception("Không có đơn hàng nào để chạy");
                }
                else
                {
                    var dsWaiting = (from o in donHangs
                                    where temp.Contains(o.Stt.ToString()) && (o.Status == (int)DonHangStatus.WAITING || o.Status == DonHangStatus.IN_PROGRESS)
                                    select o).ToList();
                                    
                    foreach (var item in dsWaiting)
                    {
                        currentDonHang = item;
                        var lvItem = lvDonDatHang.FindItemWithText(item.Stt.ToString());
                        DemCuuForm processingForm = new DemCuuForm();
                        processingForm.FormClosed += demCuuFormClosed;
                        item.Status = DonHangStatus.IN_PROGRESS;
                        lvItem.SubItems[4].Text = item.getStatusName;
                        processingForm.Show();
                        SetRunningBtn();
                        chartTimer.Start();
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                ResetRunBtn();
                MessageBox.Show(ex.Message);
            }
        }

        private void demCuuFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((Form)sender).FormClosed -= demCuuFormClosed;
                var currentItem = lvDonDatHang.FindItemWithText(currentDonHang.Stt.ToString());
                currentItem.SubItems[4].Text = currentDonHang.getStatusName;

                ResetRunBtn();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetRunBtn()
        {
            if (isChayDonHang)
            {
                isChayDonHang = false;
                btnChayDonHang.Enabled = true;
                btnChayDonHang.Text = "Run";
                btnChayDonHang.BackColor = Color.Gray;
            }
        }

        private void SetRunningBtn()
        {
            if (!isChayDonHang)
            {
                isChayDonHang = true;
                btnChayDonHang.Enabled = false;
                btnChayDonHang.Text = "Running";
                btnChayDonHang.BackColor = Color.Red;
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var chart1Area = chart1.ChartAreas[0];

            chart1Area.AxisX.Title = "Time(minute)";
            chart1Area.AxisY.Title = "Số cừu";

            startMinute = DateTime.Now.Minute;

            chartTimer.Interval = 20*1000;
            chartTimer.Tick += ChartTimer_Tick;
        }

        private void ChartTimer_Tick(object sender, EventArgs e)
        {
            chart1.Series["dataChart1"].Points.AddXY(startMinute, nextBarChartValue);
            nextBarChartValue = 0;
            startMinute++;


            chart2.Series["pieSeries"].Points.Clear();
            //black
            chart2.Series["pieSeries"].Points.AddXY("đen", blackSheepCounter);
            chart2.Series["pieSeries"].Points[0].Color = Color.Black;

            //white
            chart2.Series["pieSeries"].Points.AddXY("trắng", whiteSheepCounter);
            chart2.Series["pieSeries"].Points[1].Color = Color.White;

            //gray
            chart2.Series["pieSeries"].Points.AddXY("xám", graySheepCounter);
            chart2.Series["pieSeries"].Points[2].Color = Color.Gray;

        }
    }
}
