using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

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

                        lblKhoiLuong.Text = _khoiLuong.ToString();
                        lblKhoiLuongLong.Text = ((_khoiLuong * _tyLeLong) / 100.0).ToString();
                        pbSheepColor.Image = iconIML.Images[_mauIdx];

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
    }
}
