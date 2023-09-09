using LinuxPackageInstaller.Library;
using PackageFileReader;
using PackageFileReader.Library;

namespace LinuxPackageInstaller
{
    public partial class MainWindow : Form
    {
        private List<PackageFileReader.PackageModel> packages;
        private List<String> RepositoryList;
        public MainWindow()
        {
            InitializeComponent();
            RepositoryList = new List<String>();
            packages = new List<PackageFileReader.PackageModel>();

            RepositoryList.Add("http://ftp.debian.org/debian/");

            DownloadFile.Download(RepositoryList[0] + "dists/Debian12.1/contrib/binary-all/Packages.gz", "ContribPackages.gz");
            Unzip.UnzipFile("ContribPackages.gz", "ContribPackages");

            DownloadFile.Download(RepositoryList[0] + "/dists/Debian12.1/main/binary-all/Packages.gz", "MainPackages.gz");
            Unzip.UnzipFile("MainPackages.gz", "MainPackages");

            DownloadFile.Download(RepositoryList[0] + "/dists/Debian12.1/non-free-firmware/binary-all/Packages.gz", "NonFreeFirmwarePackages.gz");
            Unzip.UnzipFile("NonFreeFirmwarePackages.gz", "NonFreeFirmwarePackages");

            DownloadFile.Download(RepositoryList[0] + "/dists/Debian12.1/non-free/binary-all/Packages.gz", "NonFreePackages.gz");
            Unzip.UnzipFile("NonFreePackages.gz", "NonFreePackages");

            PackageRead.ReturnList("ContribPackages").ForEach(x =>
            {
                listView1.Items.Add(x.Name.ToString());
                packages.Add(x);
            });
            PackageRead.ReturnList("MainPackages").ForEach(x =>
            {
                listView1.Items.Add(x.Name.ToString());
                packages.Add(x);
            });
            PackageRead.ReturnList("NonFreeFirmwarePackages").ForEach(x =>
            {
                listView1.Items.Add(x.Name.ToString());
                packages.Add(x);
            });
            PackageRead.ReturnList("NonFreePackages").ForEach(x =>
            {
                listView1.Items.Add(x.Name.ToString());
                packages.Add(x);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            packages.ForEach(x =>
            {
                if (x.Name == listView1.SelectedItems[0].Text.ToString())
                {
                    string url = "http://ftp.debian.org/debian/" + x.Url.Trim();
                    DownloadFile.Download(url, x.Name);
                }
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.ToString().Equals(""))
            {
                listView1.Clear();
                packages.ForEach(x =>
                {
                    if (x.Name.ToString().IndexOf(textBox1.Text.ToString()) > -1)
                    {
                        listView1.Items.Add(x.Name.ToString());
                    }
                });
            }
        }
    }
}