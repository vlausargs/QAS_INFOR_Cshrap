//PROJECT NAME: Logistics
//CLASS NAME: DeleteTmpSerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class DeleteTmpSerFactory
	{
		public IDeleteTmpSer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteTmpSer = new Logistics.FieldService.Requests.DeleteTmpSer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTmpSerExt = timerfactory.Create<Logistics.FieldService.Requests.IDeleteTmpSer>(_DeleteTmpSer);
			
			return iDeleteTmpSerExt;
		}
	}
}
