//PROJECT NAME: Production
//CLASS NAME: PsQtyValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PsQtyValidFactory
	{
		public IPsQtyValid Create(IApplicationDB appDB)
		{
			var _PsQtyValid = new Production.PsQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsQtyValidExt = timerfactory.Create<Production.IPsQtyValid>(_PsQtyValid);
			
			return iPsQtyValidExt;
		}
	}
}
