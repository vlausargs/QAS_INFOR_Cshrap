//PROJECT NAME: Finance
//CLASS NAME: CHSCheckChinFinFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CHSCheckChinFinFactory
	{
		public ICHSCheckChinFin Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSCheckChinFin = new Finance.CHSCheckChinFin(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCheckChinFinExt = timerfactory.Create<Finance.ICHSCheckChinFin>(_CHSCheckChinFin);
			
			return iCHSCheckChinFinExt;
		}
	}
}
