//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransMiscCstPrcTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransMiscCstPrcTaxFactory
	{
		public ISSSFSSROTransMiscCstPrcTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransMiscCstPrcTax = new Logistics.FieldService.Requests.SSSFSSROTransMiscCstPrcTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransMiscCstPrcTaxExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransMiscCstPrcTax>(_SSSFSSROTransMiscCstPrcTax);
			
			return iSSSFSSROTransMiscCstPrcTaxExt;
		}
	}
}
