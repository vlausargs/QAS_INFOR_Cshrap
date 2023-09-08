//PROJECT NAME: Material
//CLASS NAME: MrpParmChkLowSetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpParmChkLowSetFactory
	{
		public IMrpParmChkLowSet Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpParmChkLowSet = new Material.MrpParmChkLowSet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpParmChkLowSetExt = timerfactory.Create<Material.IMrpParmChkLowSet>(_MrpParmChkLowSet);
			
			return iMrpParmChkLowSetExt;
		}
	}
}
