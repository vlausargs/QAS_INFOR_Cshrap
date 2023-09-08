//PROJECT NAME: CSICodes
//CLASS NAME: GetWcompIndustryClassificationFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetWcompIndustryClassificationFactory
    {
        public IGetWcompIndustryClassification Create(IApplicationDB appDB)
        {
            var _GetWcompIndustryClassification = new GetWcompIndustryClassification(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetWcompIndustryClassificationExt = timerfactory.Create<IGetWcompIndustryClassification>(_GetWcompIndustryClassification);

            return iGetWcompIndustryClassificationExt;
        }
    }
}