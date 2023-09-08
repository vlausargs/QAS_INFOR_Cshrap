//PROJECT NAME: Data.Functions
//CLASS NAME: ConvertSecondsToTimeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Data.Functions
{
    public class ConvertSecondsToTimeFactory
    {
        public const string IDO = "EmptyIDO";
        public const string Method = "ConvertSecondsToTime";

        public IConvertSecondsToTime Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var convertToUtil = new ConvertToUtilFactory().Create();
            var stringUtil = new StringUtil();
            var mathUtil = new MathUtilFactory().Create();

            IConvertSecondsToTime _ConvertSecondsToTime = new ConvertSecondsToTime(appDB,
                convertToUtil,
                stringUtil,
                mathUtil);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iConvertSecondsToTimeExt = timerfactory.Create<IConvertSecondsToTime>(_ConvertSecondsToTime);

            return iConvertSecondsToTimeExt;
        }
    }
}
