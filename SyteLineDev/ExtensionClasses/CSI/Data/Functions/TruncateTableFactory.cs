//PROJECT NAME: Data.Functions
//CLASS NAME: TruncateTableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class TruncateTableFactory
	{
		public ITruncateTable Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _TruncateTable = new TruncateTable(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTruncateTableExt = timerfactory.Create<ITruncateTable>(_TruncateTable);

			return iTruncateTableExt;
		}
	}
}
