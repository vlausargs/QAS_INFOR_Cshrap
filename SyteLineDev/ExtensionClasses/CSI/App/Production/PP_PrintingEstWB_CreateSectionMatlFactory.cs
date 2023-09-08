//PROJECT NAME: Production
//CLASS NAME: PP_PrintingEstWB_CreateSectionMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_PrintingEstWB_CreateSectionMatlFactory
	{
		public IPP_PrintingEstWB_CreateSectionMatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_PrintingEstWB_CreateSectionMatl = new Production.PP_PrintingEstWB_CreateSectionMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_PrintingEstWB_CreateSectionMatlExt = timerfactory.Create<Production.IPP_PrintingEstWB_CreateSectionMatl>(_PP_PrintingEstWB_CreateSectionMatl);
			
			return iPP_PrintingEstWB_CreateSectionMatlExt;
		}
	}
}
