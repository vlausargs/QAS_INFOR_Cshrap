//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBGetFiscalYearStartAndEndDateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBGetFiscalYearStartAndEndDateFactory
    {
        public IMultiFSBGetFiscalYearStartAndEndDate Create(IApplicationDB appDB)
        {
            var _MultiFSBGetFiscalYearStartAndEndDate = new MultiFSBGetFiscalYearStartAndEndDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbsExt = timerfactory.Create<IMultiFSBGetFiscalYearStartAndEndDate>(_MultiFSBGetFiscalYearStartAndEndDate);

            return iSLFsbsExt;
        }
    }
}
