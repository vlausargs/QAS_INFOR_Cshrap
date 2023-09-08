//PROJECT NAME: CSIPPIndPack
//CLASS NAME: PP_GetNextQuoteSectionNumberFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetNextQuoteSectionNumberFactory
	{
		public IPP_GetNextQuoteSectionNumber Create(IApplicationDB appDB)
		{
			var _PP_GetNextQuoteSectionNumber = new Production.PrintingPackaging.PP_GetNextQuoteSectionNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GetNextQuoteSectionNumberExt = timerfactory.Create<Production.PrintingPackaging.IPP_GetNextQuoteSectionNumber>(_PP_GetNextQuoteSectionNumber);
			
			return iPP_GetNextQuoteSectionNumberExt;
		}
	}
}
