//PROJECT NAME: CSIMaterial
//CLASS NAME: SetTrnExportValueFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SetTrnExportValueFactory
    {
        public ISetTrnExportValue Create(IApplicationDB appDB)
        {
            var _SetTrnExportValue = new SetTrnExportValue(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetTrnExportValueExt = timerfactory.Create<ISetTrnExportValue>(_SetTrnExportValue);

            return iSetTrnExportValueExt;
        }
    }
}
