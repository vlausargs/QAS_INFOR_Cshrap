//PROJECT NAME: CSIMaterial
//CLASS NAME: GetDemandIDFromPLNFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetDemandIDFromPLNFactory
    {
        public IGetDemandIDFromPLN Create(IApplicationDB appDB)
        {
            var _GetDemandIDFromPLN = new GetDemandIDFromPLN(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetDemandIDFromPLNExt = timerfactory.Create<IGetDemandIDFromPLN>(_GetDemandIDFromPLN);

            return iGetDemandIDFromPLNExt;
        }
    }
}
