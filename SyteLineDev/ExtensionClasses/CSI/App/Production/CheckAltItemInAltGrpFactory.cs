//PROJECT NAME: CSIProduct
//CLASS NAME: CheckAltItemInAltGrpFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CheckAltItemInAltGrpFactory
	{
		public ICheckAltItemInAltGrp Create(IApplicationDB appDB)
		{
			var _CheckAltItemInAltGrp = new Production.CheckAltItemInAltGrp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckAltItemInAltGrpExt = timerfactory.Create<Production.ICheckAltItemInAltGrp>(_CheckAltItemInAltGrp);
			
			return iCheckAltItemInAltGrpExt;
		}
	}
}
