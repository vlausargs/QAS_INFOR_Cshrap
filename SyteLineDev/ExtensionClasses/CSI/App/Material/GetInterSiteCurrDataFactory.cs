//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInterSiteCurrDataFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetInterSiteCurrDataFactory
    {
        public IGetInterSiteCurrData Create(IApplicationDB appDB)
        {
            var _GetInterSiteCurrData = new GetInterSiteCurrData(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetInterSiteCurrDataExt = timerfactory.Create<IGetInterSiteCurrData>(_GetInterSiteCurrData);

            return iGetInterSiteCurrDataExt;
        }
    }
}
