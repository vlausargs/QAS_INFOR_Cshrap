//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetTableColsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetTableColsFactory
	{
		public IExtFinGetTableCols Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ExtFinGetTableCols = new Finance.ExtFin.ExtFinGetTableCols(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtFinGetTableColsExt = timerfactory.Create<Finance.ExtFin.IExtFinGetTableCols>(_ExtFinGetTableCols);
			
			return iExtFinGetTableColsExt;
		}
	}
}
