//PROJECT NAME: Production
//CLASS NAME: CopyBomLeaveItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CopyBomLeaveItemFactory
	{
		public ICopyBomLeaveItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CopyBomLeaveItem = new Production.CopyBomLeaveItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveItemExt = timerfactory.Create<Production.ICopyBomLeaveItem>(_CopyBomLeaveItem);
			
			return iCopyBomLeaveItemExt;
		}
	}
}
