//PROJECT NAME: CSICustomer
//CLASS NAME: ConInvStdFormPreDispFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ConInvStdFormPreDispFactory
    {
        public IConInvStdFormPreDisp Create(IApplicationDB appDB)
        {
            var _ConInvStdFormPreDisp = new ConInvStdFormPreDisp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iConInvStdFormPreDispExt = timerfactory.Create<IConInvStdFormPreDisp>(_ConInvStdFormPreDisp);

            return iConInvStdFormPreDispExt;
        }
    }
}