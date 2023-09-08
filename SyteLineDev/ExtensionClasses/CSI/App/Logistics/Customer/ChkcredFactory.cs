//PROJECT NAME: Logistics.Customer
//CLASS NAME: ChkcredFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class ChkcredFactory
    {
        public IChkcred Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _Chkcred = new Logistics.Customer.Chkcred(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChkcredExt = timerfactory.Create<Logistics.Customer.IChkcred>(_Chkcred);

            return iChkcredExt;
        }
    }
}
