//PROJECT NAME: Production
//CLASS NAME: MO_SHIFTEXDIMaintIDQueryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class MO_SHIFTEXDIMaintIDQueryFactory
	{
		public IMO_SHIFTEXDIMaintIDQuery Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_SHIFTEXDIMaintIDQuery = new Production.APS.MO_SHIFTEXDIMaintIDQuery(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_SHIFTEXDIMaintIDQueryExt = timerfactory.Create<Production.APS.IMO_SHIFTEXDIMaintIDQuery>(_MO_SHIFTEXDIMaintIDQuery);
			
			return iMO_SHIFTEXDIMaintIDQueryExt;
		}
	}
}
