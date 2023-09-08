//PROJECT NAME: Production
//CLASS NAME: GetBATPRODIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class GetBATPRODIDFactory
	{
		public IGetBATPRODID Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetBATPRODID = new Production.APS.GetBATPRODID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetBATPRODIDExt = timerfactory.Create<Production.APS.IGetBATPRODID>(_GetBATPRODID);
			
			return iGetBATPRODIDExt;
		}
	}
}
