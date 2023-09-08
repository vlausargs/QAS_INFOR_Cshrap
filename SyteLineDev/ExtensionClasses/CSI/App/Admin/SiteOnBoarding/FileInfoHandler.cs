using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IFileInfoHandler
    {
        Dictionary<string, string> SettleFileName(string fileName);
    }

    public class FileInfoHandler : IFileInfoHandler
    {
        public Dictionary<string, string> SettleFileName(string fileName)
        {
            var fileInfo = new Dictionary<string, string>();

            var fileNameAnalysis = Regex.Split(fileName, @"(\.)|(-)")
                .Where(m => !string.IsNullOrEmpty(m) && !m.Contains("-") && !m.Contains("."))
                .ToList();

            switch (fileNameAnalysis.Count)
            {
                case 6:
                    fileInfo.Add("FileName", fileName);
                    fileInfo.Add("TableName", fileNameAnalysis[0]);
                    fileInfo.Add("Site", fileNameAnalysis[1]);
                    fileInfo.Add("DBLevel", fileNameAnalysis[2]);
                    fileInfo.Add("TotalTasks", fileNameAnalysis[3]);
                    fileInfo.Add("TaskNum", fileNameAnalysis[4]);
                    fileInfo.Add("FileType", fileNameAnalysis[5]);
                    break;
                case 7:
                    fileInfo.Add("FileName", fileName);
                    fileInfo.Add("RelevantTableName", fileNameAnalysis[0]);
                    fileInfo.Add("TableName", fileNameAnalysis[1]);
                    fileInfo.Add("Site", fileNameAnalysis[2]);
                    fileInfo.Add("DBLevel", fileNameAnalysis[3]);
                    fileInfo.Add("TotalTasks", fileNameAnalysis[4]);
                    fileInfo.Add("TaskNum", fileNameAnalysis[5]);
                    fileInfo.Add("FileType", fileNameAnalysis[6]);
                    break;
            }

            return fileInfo;
        }
    }
}