//PROJECT NAME: Logistics
//CLASS NAME: TmpConInvGenerationUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class TmpConInvGenerationUpdFactory
	{
		public ITmpConInvGenerationUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TmpConInvGenerationUpd = new Logistics.Customer.TmpConInvGenerationUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTmpConInvGenerationUpdExt = timerfactory.Create<Logistics.Customer.ITmpConInvGenerationUpd>(_TmpConInvGenerationUpd);
			
			return iTmpConInvGenerationUpdExt;
		}
	}
}
