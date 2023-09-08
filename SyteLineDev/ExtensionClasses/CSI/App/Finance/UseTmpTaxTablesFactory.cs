//PROJECT NAME: Finance
//CLASS NAME: UseTmpTaxTablesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class UseTmpTaxTablesFactory
	{
		public IUseTmpTaxTables Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _UseTmpTaxTables = new Finance.UseTmpTaxTables(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUseTmpTaxTablesExt = timerfactory.Create<Finance.IUseTmpTaxTables>(_UseTmpTaxTables);
			
			return iUseTmpTaxTablesExt;
		}
	}
}
