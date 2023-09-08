//PROJECT NAME: Employee
//CLASS NAME: MessageToPrtrxToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class MessageToPrtrxToPrintPostFactory
	{
		public IMessageToPrtrxToPrintPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MessageToPrtrxToPrintPost = new Employee.MessageToPrtrxToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMessageToPrtrxToPrintPostExt = timerfactory.Create<Employee.IMessageToPrtrxToPrintPost>(_MessageToPrtrxToPrintPost);
			
			return iMessageToPrtrxToPrintPostExt;
		}
	}
}
