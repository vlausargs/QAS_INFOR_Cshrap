//PROJECT NAME: CSIProduct
//CLASS NAME: ProdSchedNextKeyDelFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class ProdSchedNextKeyDelFactory
    {
        public IProdSchedNextKeyDel Create(IApplicationDB appDB)
        {
            var _ProdSchedNextKeyDel = new ProdSchedNextKeyDel(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProdSchedNextKeyDelExt = timerfactory.Create<IProdSchedNextKeyDel>(_ProdSchedNextKeyDel);

            return iProdSchedNextKeyDelExt;
        }
    }
}
