//PROJECT NAME: Production
//CLASS NAME: XrefWarningMessageFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class XrefWarningMessageFactory
	{
		public IXrefWarningMessage Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _XrefWarningMessage = new Production.XrefWarningMessage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iXrefWarningMessageExt = timerfactory.Create<Production.IXrefWarningMessage>(_XrefWarningMessage);
			
			return iXrefWarningMessageExt;
		}
	}
}
