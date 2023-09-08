//PROJECT NAME: CSIMaterial
//CLASS NAME: RvallocFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RvallocFactory
    {
        public IRvalloc Create(IApplicationDB appDB)
        {
            var _Rvalloc = new Material.Rvalloc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRvallocExt = timerfactory.Create<Material.IRvalloc>(_Rvalloc);

            return iRvallocExt;
        }
    }
}
