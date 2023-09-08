//PROJECT NAME: CSIProduct
//CLASS NAME: MO_AddAlternateFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class MO_AddAlternateFactory
	{
		public IMO_AddAlternate Create(IApplicationDB appDB)
		{
			var _MO_AddAlternate = new Production.MO_AddAlternate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_AddAlternateExt = timerfactory.Create<Production.IMO_AddAlternate>(_MO_AddAlternate);
			
			return iMO_AddAlternateExt;
		}
	}
}
