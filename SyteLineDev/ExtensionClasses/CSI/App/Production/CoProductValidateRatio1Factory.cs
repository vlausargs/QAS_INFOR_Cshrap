//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductValidateRatio1Factory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CoProductValidateRatio1Factory
    {
        public ICoProductValidateRatio1 Create(IApplicationDB appDB)
        {
            var _CoProductValidateRatio1 = new CoProductValidateRatio1(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoProductValidateRatio1Ext = timerfactory.Create<ICoProductValidateRatio1>(_CoProductValidateRatio1);

            return iCoProductValidateRatio1Ext;
        }
    }
}
