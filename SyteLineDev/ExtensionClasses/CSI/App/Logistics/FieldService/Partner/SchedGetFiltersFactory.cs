//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedGetFiltersFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SchedGetFiltersFactory
    {
        public ISchedGetFilters Create(IApplicationDB appDB)
        {
            var _SchedGetFilters = new SchedGetFilters(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSchedGetFiltersExt = timerfactory.Create<ISchedGetFilters>(_SchedGetFilters);

            return iSchedGetFiltersExt;
        }
    }
}
