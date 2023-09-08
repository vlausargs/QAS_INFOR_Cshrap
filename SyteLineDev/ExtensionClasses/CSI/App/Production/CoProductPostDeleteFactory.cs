//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductPostDeleteFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CoProductPostDeleteFactory
    {
        public ICoProductPostDelete Create(IApplicationDB appDB)
        {
            var _CoProductPostDelete = new CoProductPostDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoProductPostDeleteExt = timerfactory.Create<ICoProductPostDelete>(_CoProductPostDelete);

            return iCoProductPostDeleteExt;
        }
    }
}
