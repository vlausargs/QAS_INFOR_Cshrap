//PROJECT NAME: CSICodes
//CLASS NAME: HorizonValidStartDateFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class HorizonValidStartDateFactory
	{
		public IHorizonValidStartDate Create(IApplicationDB appDB)
		{
			var _HorizonValidStartDate = new Codes.HorizonValidStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHorizonValidStartDateExt = timerfactory.Create<Codes.IHorizonValidStartDate>(_HorizonValidStartDate);
			
			return iHorizonValidStartDateExt;
		}
	}
}
