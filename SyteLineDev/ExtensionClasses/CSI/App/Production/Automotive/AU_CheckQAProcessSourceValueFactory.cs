//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CheckQAProcessSourceValueFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
	public class AU_CheckQAProcessSourceValueFactory
	{
		public IAU_CheckQAProcessSourceValue Create(IApplicationDB appDB)
		{
			var _AU_CheckQAProcessSourceValue = new Production.Automotive.AU_CheckQAProcessSourceValue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CheckQAProcessSourceValueExt = timerfactory.Create<Production.Automotive.IAU_CheckQAProcessSourceValue>(_AU_CheckQAProcessSourceValue);
			
			return iAU_CheckQAProcessSourceValueExt;
		}
	}
}
