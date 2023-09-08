//PROJECT NAME: CSIMaterial
//CLASS NAME: GetApsIDFromPLNFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetApsIDFromPLNFactory
    {
        public IGetApsIDFromPLN Create(IApplicationDB appDB)
        {
            var _GetApsIDFromPLN = new GetApsIDFromPLN(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetApsIDFromPLNExt = timerfactory.Create<IGetApsIDFromPLN>(_GetApsIDFromPLN);

            return iGetApsIDFromPLNExt;
        }
    }
}
