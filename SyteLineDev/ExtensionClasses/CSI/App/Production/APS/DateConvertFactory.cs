//PROJECT NAME: Production
//CLASS NAME: DateConvertFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class DateConvertFactory
	{
		public IDateConvert Create(IApplicationDB appDB)
		{
			var _DateConvert = new Production.APS.DateConvert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDateConvertExt = timerfactory.Create<Production.APS.IDateConvert>(_DateConvert);
			
			return iDateConvertExt;
		}
	}
}
