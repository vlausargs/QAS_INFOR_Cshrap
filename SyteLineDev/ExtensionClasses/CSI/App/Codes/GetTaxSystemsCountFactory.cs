//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxSystemsCountFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetTaxSystemsCountFactory
	{
		public IGetTaxSystemsCount Create(IApplicationDB appDB)
		{
			var _GetTaxSystemsCount = new Codes.GetTaxSystemsCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTaxSystemsCountExt = timerfactory.Create<Codes.IGetTaxSystemsCount>(_GetTaxSystemsCount);
			
			return iGetTaxSystemsCountExt;
		}
	}
}
