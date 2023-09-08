//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxParmsTaxRegNumFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetTaxParmsTaxRegNumFactory
	{
		public IGetTaxParmsTaxRegNum Create(IApplicationDB appDB)
		{
			var _GetTaxParmsTaxRegNum = new Codes.GetTaxParmsTaxRegNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTaxParmsTaxRegNumExt = timerfactory.Create<Codes.IGetTaxParmsTaxRegNum>(_GetTaxParmsTaxRegNum);
			
			return iGetTaxParmsTaxRegNumExt;
		}
	}
}
