//PROJECT NAME: CSIProduct
//CLASS NAME: CheckAltItemExistFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CheckAltItemExistFactory
	{
		public ICheckAltItemExist Create(IApplicationDB appDB)
		{
			var _CheckAltItemExist = new Production.CheckAltItemExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckAltItemExistExt = timerfactory.Create<Production.ICheckAltItemExist>(_CheckAltItemExist);
			
			return iCheckAltItemExistExt;
		}
	}
}
