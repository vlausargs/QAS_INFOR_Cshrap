//PROJECT NAME: Production
//CLASS NAME: PP_GetStandardUMParmFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetStandardUMParmFactory
	{
		public IPP_GetStandardUMParm Create(IApplicationDB appDB)
		{
			var _PP_GetStandardUMParm = new Production.PrintingPackaging.PP_GetStandardUMParm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GetStandardUMParmExt = timerfactory.Create<Production.PrintingPackaging.IPP_GetStandardUMParm>(_PP_GetStandardUMParm);
			
			return iPP_GetStandardUMParmExt;
		}
	}
}
