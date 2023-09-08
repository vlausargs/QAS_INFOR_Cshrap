//PROJECT NAME: CSICodes
//CLASS NAME: TaxCodeValidFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class TaxCodeValidFactory
	{
		public ITaxCodeValid Create(IApplicationDB appDB)
		{
			var _TaxCodeValid = new Codes.TaxCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxCodeValidExt = timerfactory.Create<Codes.ITaxCodeValid>(_TaxCodeValid);
			
			return iTaxCodeValidExt;
		}
	}
}
