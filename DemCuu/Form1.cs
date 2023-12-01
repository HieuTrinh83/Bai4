using DemCuu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DemCuu
{
    public partial class formBai4 : Form
    {
        Thread thrdDemCuu;
        private Random r;
        private int tgDem; //second
        private bool isPlaying = false;
        private const int BLACK_IDX = 0;
        private const int WHITE_IDX = 1;
        private const int GRAY_IDX = 2;
        private List<string> dsColor = new List<string> { "black", "white", "gray" };

        private List<Sheep> dsWhite = new List<Sheep>();
        private List<Sheep> dsBlack = new List<Sheep>();
        private List<Sheep> dsGray = new List<Sheep>();

        public formBai4()
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

            thrdDemCuu = new Thread(DemCuu);
            thrdDemCuu.Start();
        }

        private void formBai4_Load(object sender, EventArgs e)
        {
        }

        private void DemCuu()
        {
            try {
                int _khoiLuong = 0;
                int _tyLeLong = 0; //%
                int _mauIdx = 0;

                int soLuong = 0, dem = 1;

                if (Int32.TryParse(txtSoluong.Text, out soLuong))
                {
                    while (isPlaying && dem <= soLuong)
                    {

                        lblStt.Text = dem.ToString();
                        _khoiLuong = r.Next(30, 61);
                        _tyLeLong = r.Next(3, 8);
                        _mauIdx = r.Next(0, 3);

                        float khoiLuongLong = (float)(_khoiLuong * _tyLeLong) / 100;
                        var sheep = new Sheep(_khoiLuong, _mauIdx, khoiLuongLong);
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

                        lblKhoiLuong.Text = sheep.KhoiLuong.ToString();
                        lblKhoiLuongLong.Text = sheep.KhoiLuongLong.ToString();
                        pbSheepColor.Image = iconIML.Images[sheep.ColorIdx];

                        if (!isPlaying || soLuong == dem)
                        {
                            break;
                        }

                        dem++;
                        tgDem = r.Next(1, 6);

                        Thread.Sleep(tgDem * 1000);
                    }

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

        private void btnLuuExcel_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            var junkName = $"{now.Year}{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}";

            var fileNameWhiteSheep = $"{currentDirectory}/white_{junkName}";
            var fileNameBlackSheep = $"{currentDirectory}/black_{junkName}";
            var fileNameGraySheep = $"{currentDirectory}/gray_{junkName}";

            LuuExcel(fileNameWhiteSheep, dsWhite);
            LuuExcel(fileNameBlackSheep, dsBlack);
            LuuExcel(fileNameGraySheep, dsGray);
        }

        private void LuuExcel(string fileName, List<Sheep> dsSheep) {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets["sheet1"];

                excelWorksheet.Columns[1].ColumnWidth = 7;
                excelWorksheet.Columns[2].ColumnWidth = 15;
                excelWorksheet.Columns[3].ColumnWidth = 20;

                excelWorksheet.Cells[1, 1] = "STT";
                excelWorksheet.Cells[1, 2] = "Khối Lượng";
                excelWorksheet.Cells[1, 3] = "Khối Lượng Lông";

                int idx = 1;
                foreach (var item in dsSheep)
                {
                    idx++;
                    excelWorksheet.Cells[idx, 1] = idx - 1;
                    excelWorksheet.Cells[idx, 2] = item.KhoiLuong;
                    excelWorksheet.Cells[idx, 3] = item.KhoiLuongLong;
                }
                excelApp.ActiveWorkbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);

                excelWorkbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
