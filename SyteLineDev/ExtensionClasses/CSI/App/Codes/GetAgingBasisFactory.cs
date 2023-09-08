//PROJECT NAME: CSICodes
//CLASS NAME: GetAgingBasisFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetAgingBasisFactory
	{
		public IGetAgingBasis Create(IApplicationDB appDB)
		{
			var _GetAgingBasis = new Codes.GetAgingBasis(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAgingBasisExt = timerfactory.Create<Codes.IGetAgingBasis>(_GetAgingBasis);
			
			return iGetAgingBasisExt;
		}
	}
}
