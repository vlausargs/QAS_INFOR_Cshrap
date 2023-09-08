//PROJECT NAME: CSIMaterial
//CLASS NAME: GetCoItemDetailFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetCoItemDetailFactory
    {
        public IGetCoItemDetail Create(IApplicationDB appDB)
        {
            var _GetCoItemDetail = new GetCoItemDetail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCoItemDetailExt = timerfactory.Create<IGetCoItemDetail>(_GetCoItemDetail);

            return iGetCoItemDetailExt;
        }
    }
}
