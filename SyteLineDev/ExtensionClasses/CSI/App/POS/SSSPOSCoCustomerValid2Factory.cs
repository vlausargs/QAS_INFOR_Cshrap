//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCoCustomerValid2Factory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSCoCustomerValid2Factory
    {
        public ISSSPOSCoCustomerValid2 Create(IApplicationDB appDB)
        {
            var _SSSPOSCoCustomerValid2 = new POS.SSSPOSCoCustomerValid2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSCoCustomerValid2Ext = timerfactory.Create<POS.ISSSPOSCoCustomerValid2>(_SSSPOSCoCustomerValid2);

            return iSSSPOSCoCustomerValid2Ext;
        }
    }
}
