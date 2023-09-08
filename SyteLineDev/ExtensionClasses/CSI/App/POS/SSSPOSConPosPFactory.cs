//PROJECT NAME: POS
//CLASS NAME: SSSPOSConPosPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.POS
{
	public class SSSPOSConPosPFactory
	{
		public ISSSPOSConPosP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSPOSConPosP = new POS.SSSPOSConPosP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSConPosPExt = timerfactory.Create<POS.ISSSPOSConPosP>(_SSSPOSConPosP);
			
			return iSSSPOSConPosPExt;
		}
	}
}
