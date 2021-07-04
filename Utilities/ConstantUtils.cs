using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Utilities
{
    public class ConstantUtils
    {
        //Site Url
        public static string Url = "http://localhost:5000";

        // Excel path
        public static String DataFilePath = Directory.GetCurrentDirectory() + @"\SkillSwap\ExcelData\TestDataManageListings.xlsx";

        // Path to Save Screenshots
        public static String ScreenshotPath = Directory.GetCurrentDirectory() + @"\SkillSwap\TestReports\Screenshots";

        // ExtentReport path
        public static String ReportsPath = Directory.GetCurrentDirectory() + @"\SkillSwap\TestReports\index.html";
    }
}
