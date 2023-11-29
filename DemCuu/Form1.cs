using System;
using System.Threading;
using System.Windows.Forms;

namespace DemCuu
{
    public partial class formBai4 : Form
    {
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private bool isPlaying = false;
        private const int BLACK_IDX = 0;
        private const int WHITE_IDX = 1;
        private const int GRAY_IDX = 2;

        public formBai4()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isPlaying = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;

            new Thread(hayvd).Start();
        }

        private void formBai4_Load(object sender, EventArgs e)
        {

        }

        private void hayvd()
        {
            int _khoiLuong = 0;
            int _tyLeLong = 0; //%
            int _mauIdx = 0;

            Random r = new Random();

            int soLuong = 0, dem = 1;

            if (Int32.TryParse(txtSoluong.Text, out soLuong))
            {
                while (isPlaying)
                {

                    lblStt.Text = dem.ToString();
                    _khoiLuong = r.Next(30, 60);
                    _tyLeLong = r.Next(3, 7);
                    _mauIdx = r.Next(0, 2);

                    lblKhoiLuong.Text = _khoiLuong.ToString();
                    lblKhoiLuongLong.Text = ((_khoiLuong * _tyLeLong) / 100.0).ToString();
                    pbSheepColor.Image = iconIML.Images[_mauIdx];

                    if (!isPlaying || soLuong == dem)
                    {
                        break;
                    }
                    dem++;
                    Thread.Sleep(r.Next(1, 5) * 1000);
                }
            }
            else
            {
                // warning smt
            }
        }
    }
}
