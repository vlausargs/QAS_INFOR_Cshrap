//PROJECT NAME: CSIProduct
//CLASS NAME: CheckAltGroupExistFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CheckAltGroupExistFactory
	{
		public ICheckAltGroupExist Create(IApplicationDB appDB)
		{
			var _CheckAltGroupExist = new Production.CheckAltGroupExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckAltGroupExistExt = timerfactory.Create<Production.ICheckAltGroupExist>(_CheckAltGroupExist);
			
			return iCheckAltGroupExistExt;
		}
	}
}
