//PROJECT NAME: Finance
//CLASS NAME: ReleaseTmpTaxTablesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ReleaseTmpTaxTablesFactory
	{
		public IReleaseTmpTaxTables Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _ReleaseTmpTaxTables = new Finance.ReleaseTmpTaxTables(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReleaseTmpTaxTablesExt = timerfactory.Create<Finance.IReleaseTmpTaxTables>(_ReleaseTmpTaxTables);
			
			return iReleaseTmpTaxTablesExt;
		}
	}
}
