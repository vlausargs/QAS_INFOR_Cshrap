//PROJECT NAME: Data.Functions
//CLASS NAME: ConvertSecondsToTimeAsStrFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Data.Functions
{
    public class ConvertSecondsToTimeAsStrFactory
    {
        public const string IDO = "EmptyIDO";
        public const string Method = "ConvertSecondsToTimeAsStr";

        public IConvertSecondsToTimeAsStr Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var iConvertSecondsToTime = new ConvertSecondsToTimeFactory().Create(cSIExtensionClassBase, true);
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var stringUtil = new StringUtil();
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IConvertSecondsToTimeAsStr _ConvertSecondsToTimeAsStr = new ConvertSecondsToTimeAsStr(appDB,
                iConvertSecondsToTime,
                dateTimeUtil,
                stringUtil,
                mathUtil,
                sQLUtil);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iConvertSecondsToTimeAsStrExt = timerfactory.Create<IConvertSecondsToTimeAsStr>(_ConvertSecondsToTimeAsStr);

            return iConvertSecondsToTimeAsStrExt;
        }
    }
}
