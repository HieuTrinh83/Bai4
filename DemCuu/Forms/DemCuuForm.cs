using DemCuu.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DemCuu.Forms
{
    public partial class DemCuuForm : Form
    {
        System.Windows.Forms.Timer saveFileTimer = new System.Windows.Forms.Timer();

        Thread thrdDemCuu;
        private Random r;
        private bool isPlaying = false;
        private const int BLACK_IDX = 0;
        private const int WHITE_IDX = 1;
        private const int GRAY_IDX = 2;

        // Danh sách màu cừu
        private List<Color> dsColor = new List<Color> { Color.FromArgb(0,0,0), Color.FromArgb(255,255,255), Color.Gray };

        // Danh sách cừu theo màu theo từng đợt lưu
        private List<Sheep> dsWhite = new List<Sheep>();
        private List<Sheep> dsBlack = new List<Sheep>();
        private List<Sheep> dsGray = new List<Sheep>();

        //Danh sách toàn bộ cừu theo từng đợt lưu
        private List<Sheep> dsSheep = new List<Sheep>();

        public DemCuuForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            r = new Random();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            //Khởi tạo luồng xử lý đếm cừu
            thrdDemCuu = new Thread(DemCuu);
            thrdDemCuu.Start();

            //Timer cho xử lý lưu thông tin cừu vào các loại danh sách
            saveFileTimer.Start();
        }

        private void formBai4_Load(object sender, EventArgs e)
        {
            //Thiết lập thời gian lưu file
            saveFileTimer.Interval = 20*1000;

            //Thiết lập handler cho timer
            saveFileTimer.Tick += SaveFileTimer_Tick;
        }

        private void SaveFileTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            //Thư mục chạy
            var currentDirectory = Directory.GetCurrentDirectory();
            var junkName = $"{now.Year}{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}";

            //Thư mục cần lưu file
            var destinationDir = $"{currentDirectory}/{junkName}";

            try
            {
                //Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(destinationDir))
                {
                    Directory.CreateDirectory(destinationDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Danh sách tên các file Excel cần phải lưu
            var fileNameWhiteSheep = $"{destinationDir}/white.xlsx";
            var fileNameBlackSheep = $"{destinationDir}/black.xlsx";
            var fileNameGraySheep = $"{destinationDir}/gray.xlsx";
            var fileNameTotalSheep = $"{destinationDir}/total.xlsx";

            //Lưu file
            LuuExcel(fileNameWhiteSheep, dsWhite);
            LuuExcel(fileNameBlackSheep, dsBlack);
            LuuExcel(fileNameGraySheep, dsGray);
            LuuExcel(fileNameTotalSheep, dsSheep);
        }

        /// <summary>
        /// Phương thức dành cho thread đếm cừu
        /// </summary>
        private void DemCuu()
        {
            try {
                //Các thông số lưu tạm thời của cừu
                int _khoiLuong = 0;
                int _tyLeLong = 0; 
                int _mauIdx = 0;

                int soLuong = 0, dem = 1;

                if (Int32.TryParse(txtSoluong.Text, out soLuong))
                {
                    while (isPlaying && dem <= soLuong)
                    {
                        //Thu thập thông tin
                        lblStt.Text = dem.ToString();
                        _khoiLuong = r.Next(30, 61);
                        _tyLeLong = r.Next(3, 8);
                        _mauIdx = r.Next(0, 3);
                        int tgDem = r.Next(1, 6);
                        float khoiLuongLong = (float)(_khoiLuong * _tyLeLong) / 100;

                        //Tạo đối tượng cừu
                        var now = DateTime.Now;
                        var sheep = new Sheep(dem, _khoiLuong, _mauIdx, khoiLuongLong, now, now.AddSeconds(tgDem));

                        //Lưu thông tin cừu theo màu vào các danh sách cụ thể
                        switch (_mauIdx)
                        {
                            case WHITE_IDX:
                                dsWhite.Add(sheep);
                                break;
                            case BLACK_IDX:
                                dsBlack.Add(sheep);
                                break;
                            case GRAY_IDX:
                                dsGray.Add(sheep);
                                break;
                            default:
                                break;
                        }

                        //Lưu thông tin cừu vào danh sách tổng
                        dsSheep.Add(sheep);

                        //Đẩy thông tin cừu vào ListViewItem
                        ListViewItem item = new ListViewItem(lblStt.Text);
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(sheep.KhoiLuong.ToString("N1"));
                        item.SubItems.Add("").BackColor = dsColor[sheep.ColorIdx];
                        item.SubItems.Add(sheep.KhoiLuongLong.ToString("N2"));
                        item.SubItems.Add(sheep.Start.ToString("dd/MM/yyyy HH:mm:ss"));
                        item.SubItems.Add(sheep.End.ToString("dd/MM/yyyy HH:mm:ss"));
                        item.SubItems.Add(sheep.ProcessTime.ToString());
                        lvSheepsDetail.Items.Add(item);

                        //Do danh sách chỉ được phép hiển thị 20 con cừu được xử lý gần nhất nên ListViewItem cần phải xóa bớt
                        if (lvSheepsDetail.Items.Count > 20)
                        {
                            lvSheepsDetail.Items.RemoveAt(0);
                        }

                        //Thông tin hiển thị con cừu đang được xử lý thông tin
                        lblKhoiLuong.Text = sheep.KhoiLuong.ToString();
                        lblKhoiLuongLong.Text = sheep.KhoiLuongLong.ToString();
                        pbSheepColor.Image = iconIML.Images[sheep.ColorIdx];

                        //Break Point
                        if (!isPlaying || soLuong == dem)
                        {
                            break;
                        }
                        dem++;

                        //Đây là fake thời gian để chuyển cừu lên xe, sẽ có thay đổi trong bài toán thật sự khi làm việc vói các sensor
                        Thread.Sleep(tgDem * 1000);
                    }

                    //Thông báo hoàn thành đơn hàng
                    if(soLuong == dem)
                    {
                        MessageBox.Show("Đã hoàn thành!");
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng nhập không hợp lệ!");
                }
            } catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            thrdDemCuu.Abort(100);
            thrdDemCuu.Join();
        }

        /// <summary>
        /// Lưu thông tin của 1 danh sách thông tin cừu vào file
        /// </summary>
        /// <param name="fileName">Tên tệp cần lưu</param>
        /// <param name="ds">Danh sách cần lưu</param>
        private void LuuExcel(string fileName, List<Sheep> ds) {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage excel = new ExcelPackage())
                {
                    if (excel != null)
                    {
                        var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                        // setting the properties 
                        // of the work sheet  
                        workSheet.TabColor = Color.Black;
                        workSheet.DefaultRowHeight = 12;

                        // Setting the properties 
                        // of the first row 
                        workSheet.Row(1).Height = 20;
                        workSheet.Row(1).Style.Font.Bold = true;

                        workSheet.Cells[1, 1].Value = "STT";
                        workSheet.Cells[1, 2].Value = "Khối Lượng (kg)";
                        workSheet.Cells[1, 3].Value = "Màu sắc";
                        workSheet.Cells[1, 4].Value = "Khối Lượng Lông (kg)";
                        workSheet.Cells[1, 5].Value = "Bắt đầu";
                        workSheet.Cells[1, 6].Value = "Kết thúc";
                        workSheet.Cells[1, 7].Value = "Thời lượng";

                        workSheet.Column(1).Width = 7;
                        workSheet.Column(2).Width = 18;
                        workSheet.Column(3).Width = 10;
                        workSheet.Column(4).Width = 22;
                        workSheet.Column(5).Width = 22;
                        workSheet.Column(6).Width = 22;
                        workSheet.Column(7).Width = 15;

                        int idx = 2;
                        foreach (var item in ds)
                        {
                            workSheet.Cells[idx, 1].Value = item.Stt;
                            workSheet.Cells[idx, 2].Value = item.KhoiLuong.ToString("N1");
                            workSheet.Cells[idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet.Cells[idx, 3].Value = "";
                            workSheet.Cells[idx, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            workSheet.Cells[idx, 3].Style.Fill.BackgroundColor.SetColor(dsColor[item.ColorIdx]);
                            workSheet.Cells[idx, 4].Value = item.KhoiLuongLong.ToString("N2");
                            workSheet.Cells[idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet.Cells[idx, 5].Value = item.Start.ToString("dd/MM/yyyy HH:mm:ss");
                            workSheet.Cells[idx, 6].Value = item.End.ToString("dd/MM/yyyy HH:mm:ss");
                            workSheet.Cells[idx, 7].Value = item.ProcessTime.ToString();
                            idx++;
                        }
                        // Create File
                        FileStream objFileStrm = File.Create(fileName);
                        objFileStrm.Close();

                        // Write content to excel file  
                        File.WriteAllBytes(fileName, excel.GetAsByteArray());
                    }
                
                    ds.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
