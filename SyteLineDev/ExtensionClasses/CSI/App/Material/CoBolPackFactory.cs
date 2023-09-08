//PROJECT NAME: CSIMaterial
//CLASS NAME: CoBolPackFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CoBolPackFactory
    {
        public ICoBolPack Create(IApplicationDB appDB)
        {
            var _CoBolPack = new CoBolPack(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoBolPackExt = timerfactory.Create<ICoBolPack>(_CoBolPack);

            return iCoBolPackExt;
        }
    }
}
