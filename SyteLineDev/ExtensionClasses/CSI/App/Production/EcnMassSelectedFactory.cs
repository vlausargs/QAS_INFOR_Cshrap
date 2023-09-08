//PROJECT NAME: CSIProduct
//CLASS NAME: EcnMassSelectedFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EcnMassSelectedFactory
	{
		public IEcnMassSelected Create(IApplicationDB appDB)
		{
			var _EcnMassSelected = new Production.EcnMassSelected(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcnMassSelectedExt = timerfactory.Create<Production.IEcnMassSelected>(_EcnMassSelected);
			
			return iEcnMassSelectedExt;
		}
	}
}
