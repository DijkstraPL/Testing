using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        public async Task<int> CalculateAsync()
        {
            await Task.Delay(5000);
            return 123;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int value = await CalculateAsync();
            label1.Text = value.ToString();
            label2.Text = stopwatch.Elapsed.ToString();

            await Task.Delay(5000);
            label2.Text = stopwatch.Elapsed.ToString();

            using (var wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                label1.Text = data.Split('\n')[0].Trim();
            }
            label2.Text = stopwatch.Elapsed.ToString();
        }


        public Form1()
        {
            InitializeComponent();
        }
    }
}
