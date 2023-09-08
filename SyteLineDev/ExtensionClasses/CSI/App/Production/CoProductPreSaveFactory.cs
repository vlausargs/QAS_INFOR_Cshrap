//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductPreSaveFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CoProductPreSaveFactory
    {
        public ICoProductPreSave Create(IApplicationDB appDB)
        {
            var _CoProductPreSave = new CoProductPreSave(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoProductPreSaveExt = timerfactory.Create<ICoProductPreSave>(_CoProductPreSave);

            return iCoProductPreSaveExt;
        }
    }
}
