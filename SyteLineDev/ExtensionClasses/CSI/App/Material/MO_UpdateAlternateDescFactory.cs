//PROJECT NAME: Material
//CLASS NAME: MO_UpdateAlternateDescFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MO_UpdateAlternateDescFactory
	{
		public IMO_UpdateAlternateDesc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_UpdateAlternateDesc = new Material.MO_UpdateAlternateDesc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_UpdateAlternateDescExt = timerfactory.Create<Material.IMO_UpdateAlternateDesc>(_MO_UpdateAlternateDesc);
			
			return iMO_UpdateAlternateDescExt;
		}
	}
}
