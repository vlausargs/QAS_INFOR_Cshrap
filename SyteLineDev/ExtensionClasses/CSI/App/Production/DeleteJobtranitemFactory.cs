//PROJECT NAME: Production
//CLASS NAME: DeleteJobtranitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class DeleteJobtranitemFactory
	{
		public IDeleteJobtranitem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteJobtranitem = new Production.DeleteJobtranitem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteJobtranitemExt = timerfactory.Create<Production.IDeleteJobtranitem>(_DeleteJobtranitem);
			
			return iDeleteJobtranitemExt;
		}
	}
}
