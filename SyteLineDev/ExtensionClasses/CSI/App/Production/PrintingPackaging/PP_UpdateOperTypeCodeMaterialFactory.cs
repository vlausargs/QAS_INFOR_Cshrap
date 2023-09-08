//PROJECT NAME: Production
//CLASS NAME: PP_UpdateOperTypeCodeMaterialFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_UpdateOperTypeCodeMaterialFactory
	{
		public IPP_UpdateOperTypeCodeMaterial Create(IApplicationDB appDB)
		{
			var _PP_UpdateOperTypeCodeMaterial = new Production.PrintingPackaging.PP_UpdateOperTypeCodeMaterial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_UpdateOperTypeCodeMaterialExt = timerfactory.Create<Production.PrintingPackaging.IPP_UpdateOperTypeCodeMaterial>(_PP_UpdateOperTypeCodeMaterial);
			
			return iPP_UpdateOperTypeCodeMaterialExt;
		}
	}
}
