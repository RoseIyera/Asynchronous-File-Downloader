using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Asynchronous_File_Downloader
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void downloadBtn_Click(object sender, EventArgs e)
        {
            downloadBtn.Enabled = false;
            await Task.Run(() => backgroundWorker1.RunWorkerAsync());
        }

        private void materialProgressBar1_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        private void progressLabel_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Reset UI state
            downloadBtn.Enabled = true;
            materialProgressBar1.Value = 0;
            progressLabel.Text = "0%";

            if (e.Error != null)
            {
                MessageBox.Show($"Error: {e.Error.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Download Complete", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            await DownloadFileWithProgressAsync(materialTextBox1.Text, materialTextBox21.Text, materialProgressBar1, progressLabel);
        }

        private async Task DownloadFileWithProgressAsync(string downloadLink, string targetPath, ProgressBar progressBar, Label labelProgress)
        {
            int bytesProcessed = 0;
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            try
            {
                WebRequest request = WebRequest.Create(downloadLink);
                if (request != null)
                {
                    double totalBytesToReceive = 0;
                    var sizeWebRequest = (HttpWebRequest)WebRequest.Create(downloadLink);
                    sizeWebRequest.Method = "HEAD";

                    using (var webResponse = await sizeWebRequest.GetResponseAsync())
                    {
                        var fileSize = webResponse.Headers.Get("Content-Length");
                        totalBytesToReceive = Convert.ToDouble(fileSize);
                    }

                    response = await request.GetResponseAsync();
                    if (response != null)
                    {
                        remoteStream = response.GetResponseStream();
                        string filePath = targetPath;
                        localStream = File.Create(targetPath);

                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;

                        do
                        {
                            bytesRead = await remoteStream.ReadAsync(buffer, 0, buffer.Length);

                            await localStream.WriteAsync(buffer, 0, bytesRead);

                            bytesProcessed += bytesRead;

                            double bytesIn = double.Parse(bytesProcessed.ToString());
                            double percentage = bytesIn / totalBytesToReceive * 100;
                            percentage = Math.Round(percentage, 0);

                            if (progressBar.InvokeRequired)
                            {
                                progressBar.Invoke(new Action(() => progressBar.Value = int.Parse(Math.Truncate(percentage).ToString())));
                            }
                            else
                            {
                                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
                            }

                            if (labelProgress.InvokeRequired)
                            {
                                labelProgress.Invoke(new Action(() => labelProgress.Text = int.Parse(Math.Truncate(percentage).ToString()) + "%"));
                            }
                            else
                            {
                                labelProgress.Text = int.Parse(Math.Truncate(percentage).ToString()) + "%";
                            }
                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
        }
    }
}
