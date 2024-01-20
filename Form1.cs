using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Asynchronous_File_Downloader
{
    public class ProgressChangedEventArgs : EventArgs
    {
        public long DownloadedBytes { get; }
        public long TotalBytes { get; }

        public ProgressChangedEventArgs(long downloadedBytes, long totalBytes)
        {
            DownloadedBytes = downloadedBytes;
            TotalBytes = totalBytes;
        }
    }

    public class AsyncFileDownloader
    {
        public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
        public event ProgressChangedEventHandler ProgressChanged;

        public async Task DownloadFileAsync(string url, string destinationPath)
        {
            using (var httpClient = new HttpClient())
            using (var fileStream = File.OpenWrite(destinationPath))
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                long downloadedBytes = 0;

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        downloadedBytes += bytesRead;

                        // Raise progress notification
                        OnProgressChanged(new ProgressChangedEventArgs(downloadedBytes, totalBytes));
                    }
                }
            }
        }

        protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }
    }

    public partial class Form1 : MaterialForm
    {
        private AsyncFileDownloader downloader;

        public Form1()
        {
            InitializeComponent();

            // Initialize the AsyncFileDownloader
            downloader = new AsyncFileDownloader();
            downloader.ProgressChanged += Downloader_ProgressChanged;
        }

        private void Downloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double progress = (double)e.DownloadedBytes / e.TotalBytes * 100;
            progressLabel.Text = $"Progress: {progress:F2}%";
            materialProgressBar1.Value = (int)progress;
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            // Specify the URL and destination path
            string url = "https://example.com/large-file.zip";
            string destinationPath = "C:\\downloads\\large-file.zip";

            // Trigger file download
            await downloader.DownloadFileAsync(url, destinationPath);
        }

        private void materialProgressBar1_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }
    }
}
