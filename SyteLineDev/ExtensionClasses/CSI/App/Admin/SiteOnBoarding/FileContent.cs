using CSI.Serializer;
using System;
using System.Text;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IFileContent
    {
        byte[] GetFileContentAndDoPreprocessing(string tableName, string appViewName, int taskSize, string taskBookMark, string targetFileType);
    }

    public class FileContent : IFileContent
    {
        private readonly IDataCollector _dataCollector;
        private readonly ISerializer _serializer;
        private readonly IDictionaryToXmlConvertor _dictionaryToXmlConvertor;

        public FileContent(IDataCollector dataCollector, ISerializer serializer, IDictionaryToXmlConvertor dictionaryToXmlConvertor)
        {
            _dataCollector = dataCollector;
            _serializer = serializer;
            _dictionaryToXmlConvertor = dictionaryToXmlConvertor;
        }

        public byte[] GetFileContentAndDoPreprocessing(string tableName, string appViewName, int taskSize, string taskBookMark, string targetFileType)
        {
            var records = _dataCollector.GetTaskData(appViewName, taskSize, tableName, taskBookMark);
            string data;
            if (targetFileType != "J")
            {
                var xmlList = _dictionaryToXmlConvertor.ConvertDictionaryToXml(tableName, appViewName, records);
                data = string.Join(Environment.NewLine, xmlList.ToArray());
            }
            else
            {
                data = _serializer.Serialize(records);
            }

            var fileContent = Encoding.ASCII.GetBytes(data);
            return fileContent;
        }
    }
}
