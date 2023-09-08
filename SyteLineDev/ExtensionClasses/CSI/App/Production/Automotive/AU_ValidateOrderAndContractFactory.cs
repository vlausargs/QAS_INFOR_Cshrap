//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_ValidateOrderAndContractFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
	public class AU_ValidateOrderAndContractFactory
	{
		public IAU_ValidateOrderAndContract Create(IApplicationDB appDB)
		{
			var _AU_ValidateOrderAndContract = new Production.Automotive.AU_ValidateOrderAndContract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_ValidateOrderAndContractExt = timerfactory.Create<Production.Automotive.IAU_ValidateOrderAndContract>(_AU_ValidateOrderAndContract);
			
			return iAU_ValidateOrderAndContractExt;
		}
	}
}
