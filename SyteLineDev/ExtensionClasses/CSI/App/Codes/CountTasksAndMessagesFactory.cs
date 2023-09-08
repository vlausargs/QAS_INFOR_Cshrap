//PROJECT NAME: Codes
//CLASS NAME: CountTasksAndMessagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class CountTasksAndMessagesFactory
	{
		public ICountTasksAndMessages Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CountTasksAndMessages = new Codes.CountTasksAndMessages(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCountTasksAndMessagesExt = timerfactory.Create<Codes.ICountTasksAndMessages>(_CountTasksAndMessages);
			
			return iCountTasksAndMessagesExt;
		}
	}
}
