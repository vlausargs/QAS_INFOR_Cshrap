//PROJECT NAME: Production
//CLASS NAME: RSQC_PrintTagsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_PrintTagsFactory
	{
		public IRSQC_PrintTags Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_PrintTags = new Production.Quality.RSQC_PrintTags(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintTagsExt = timerfactory.Create<Production.Quality.IRSQC_PrintTags>(_RSQC_PrintTags);
			
			return iRSQC_PrintTagsExt;
		}
	}
}
