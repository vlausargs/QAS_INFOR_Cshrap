//PROJECT NAME: Codes
//CLASS NAME: TaxDescFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class TaxDescFactory
	{
		public ITaxDesc Create(IApplicationDB appDB)
		{
			var _TaxDesc = new Codes.TaxDesc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDescExt = timerfactory.Create<Codes.ITaxDesc>(_TaxDesc);
			
			return iTaxDescExt;
		}
	}
}
