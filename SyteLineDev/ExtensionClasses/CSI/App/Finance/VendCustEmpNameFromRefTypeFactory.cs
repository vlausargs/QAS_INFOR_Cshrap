//PROJECT NAME: Finance
//CLASS NAME: VendCustEmpNameFromRefTypeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VendCustEmpNameFromRefTypeFactory
	{
		public IVendCustEmpNameFromRefType Create(IApplicationDB appDB)
		{
			var _VendCustEmpNameFromRefType = new Finance.VendCustEmpNameFromRefType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendCustEmpNameFromRefTypeExt = timerfactory.Create<Finance.IVendCustEmpNameFromRefType>(_VendCustEmpNameFromRefType);
			
			return iVendCustEmpNameFromRefTypeExt;
		}
	}
}
