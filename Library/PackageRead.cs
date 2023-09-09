using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxPackageInstaller.Library
{
    public class PackageRead
    {
        public static List<PackageFileReader.PackageModel> ReturnList(String PackageFileName)
        {
            List<PackageFileReader.PackageModel> packages = new List<PackageFileReader.PackageModel>();
            FileStream fileStream = new FileStream(PackageFileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            PackageFileReader.Library.PackageFileReader fileReader = new PackageFileReader.Library.PackageFileReader(streamReader.ReadToEnd());
            List<PackageFileReader.PackageModel> packageModels = fileReader.ReadPackages();
            return packageModels;  
        }
    }
}
