//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransCstPrcTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransCstPrcTaxFactory
	{
		public ISSSFSSROTransCstPrcTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransCstPrcTax = new Logistics.FieldService.Requests.SSSFSSROTransCstPrcTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransCstPrcTaxExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransCstPrcTax>(_SSSFSSROTransCstPrcTax);
			
			return iSSSFSSROTransCstPrcTaxExt;
		}
	}
}
