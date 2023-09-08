//PROJECT NAME: CSIMaterial
//CLASS NAME: AlloctrFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AlloctrFactory
    {
        public IAlloctr Create(IApplicationDB appDB)
        {
            var _Alloctr = new Alloctr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAlloctrExt = timerfactory.Create<IAlloctr>(_Alloctr);

            return iAlloctrExt;
        }
    }
}
