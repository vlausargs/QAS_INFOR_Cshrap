//PROJECT NAME: CSIMaterial
//CLASS NAME: SlocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SlocValidFactory
    {
        public ISlocValid Create(IApplicationDB appDB)
        {
            var _SlocValid = new Material.SlocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSlocValidExt = timerfactory.Create<Material.ISlocValid>(_SlocValid);

            return iSlocValidExt;
        }
    }
}
