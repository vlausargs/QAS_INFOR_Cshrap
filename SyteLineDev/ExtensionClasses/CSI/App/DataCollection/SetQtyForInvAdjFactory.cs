//PROJECT NAME: DataCollection
//CLASS NAME: SetQtyForInvAdjFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class SetQtyForInvAdjFactory
	{
		public ISetQtyForInvAdj Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetQtyForInvAdj = new DataCollection.SetQtyForInvAdj(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetQtyForInvAdjExt = timerfactory.Create<DataCollection.ISetQtyForInvAdj>(_SetQtyForInvAdj);
			
			return iSetQtyForInvAdjExt;
		}
	}
}
