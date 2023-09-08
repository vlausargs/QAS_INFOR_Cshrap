//PROJECT NAME: CSIMaterial
//CLASS NAME: ProcessTaxFreeImportUtilityFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ProcessTaxFreeImportUtilityFactory
    {
        public IProcessTaxFreeImportUtility Create(IApplicationDB appDB)
        {
            var _ProcessTaxFreeImportUtility = new ProcessTaxFreeImportUtility(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProcessTaxFreeImportUtilityExt = timerfactory.Create<IProcessTaxFreeImportUtility>(_ProcessTaxFreeImportUtility);

            return iProcessTaxFreeImportUtilityExt;
        }
    }
}
