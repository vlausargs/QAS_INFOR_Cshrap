//PROJECT NAME: Production
//CLASS NAME: PP_InsertMaterialUsageFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_InsertMaterialUsageFactory
	{
		public IPP_InsertMaterialUsage Create(IApplicationDB appDB)
		{
			var _PP_InsertMaterialUsage = new Production.PrintingPackaging.PP_InsertMaterialUsage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_InsertMaterialUsageExt = timerfactory.Create<Production.PrintingPackaging.IPP_InsertMaterialUsage>(_PP_InsertMaterialUsage);
			
			return iPP_InsertMaterialUsageExt;
		}
	}
}
