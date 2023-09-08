//PROJECT NAME: Logistics
//CLASS NAME: BuildTmpCoShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class BuildTmpCoShipFactory
	{
		public IBuildTmpCoShip Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BuildTmpCoShip = new Logistics.Customer.BuildTmpCoShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBuildTmpCoShipExt = timerfactory.Create<Logistics.Customer.IBuildTmpCoShip>(_BuildTmpCoShip);
			
			return iBuildTmpCoShipExt;
		}
	}
}
