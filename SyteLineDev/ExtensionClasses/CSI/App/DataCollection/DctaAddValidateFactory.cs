//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaAddValidateFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DctaAddValidateFactory
    {
        public IDctaAddValidate Create(IApplicationDB appDB)
        {
            var _DctaAddValidate = new DctaAddValidate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDctaAddValidateExt = timerfactory.Create<IDctaAddValidate>(_DctaAddValidate);

            return iDctaAddValidateExt;
        }
    }
}

