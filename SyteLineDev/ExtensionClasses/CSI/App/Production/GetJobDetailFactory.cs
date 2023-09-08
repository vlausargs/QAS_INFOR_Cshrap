//PROJECT NAME: CSIProduct
//CLASS NAME: GetJobDetailFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GetJobDetailFactory
    {
        public IGetJobDetail Create(IApplicationDB appDB)
        {
            var _GetJobDetail = new GetJobDetail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetJobDetailExt = timerfactory.Create<IGetJobDetail>(_GetJobDetail);

            return iGetJobDetailExt;
        }
    }
}
