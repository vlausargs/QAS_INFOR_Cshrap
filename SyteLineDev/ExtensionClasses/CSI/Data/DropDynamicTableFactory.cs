//PROJECT NAME: Data
//CLASS NAME: DropDynamicTableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data
{
	public class DropDynamicTableFactory
	{
		public IDropDynamicTable Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DropDynamicTable = new Data.DropDynamicTable(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDropDynamicTableExt = timerfactory.Create<Data.IDropDynamicTable>(_DropDynamicTable);

			return iDropDynamicTableExt;
		}
	}
}
