//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemlocAcctsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetItemlocAcctsFactory
    {
        public IGetItemlocAccts Create(IApplicationDB appDB)
        {
            var _GetItemlocAccts = new GetItemlocAccts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetItemlocAcctsExt = timerfactory.Create<IGetItemlocAccts>(_GetItemlocAccts);

            return iGetItemlocAcctsExt;
        }
    }
}
