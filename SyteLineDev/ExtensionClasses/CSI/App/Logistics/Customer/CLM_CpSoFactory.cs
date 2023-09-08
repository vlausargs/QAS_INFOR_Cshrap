//PROJECT NAME: Logistics
//CLASS NAME: CpSoFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
    public class CLM_CpSoFactory
    {
        public ICLM_CpSo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CpSo = new Logistics.Customer.CLM_CpSo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCpSoExt = timerfactory.Create<Logistics.Customer.ICLM_CpSo>(_CpSo);

            return iCpSoExt;
        }
    }
}
