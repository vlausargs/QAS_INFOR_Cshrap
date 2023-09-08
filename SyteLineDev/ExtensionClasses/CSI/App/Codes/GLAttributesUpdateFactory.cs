//PROJECT NAME: Codes
//CLASS NAME: GLAttributesUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GLAttributesUpdateFactory
	{
		public IGLAttributesUpdate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GLAttributesUpdate = new Codes.GLAttributesUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGLAttributesUpdateExt = timerfactory.Create<Codes.IGLAttributesUpdate>(_GLAttributesUpdate);
			
			return iGLAttributesUpdateExt;
		}
	}
}
