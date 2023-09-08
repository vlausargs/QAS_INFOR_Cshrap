//PROJECT NAME: CSIProduct
//CLASS NAME: EcnGetNextGroupFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EcnGetNextGroupFactory
	{
		public IEcnGetNextGroup Create(IApplicationDB appDB)
		{
			var _EcnGetNextGroup = new Production.EcnGetNextGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcnGetNextGroupExt = timerfactory.Create<Production.IEcnGetNextGroup>(_EcnGetNextGroup);
			
			return iEcnGetNextGroupExt;
		}
	}
}
