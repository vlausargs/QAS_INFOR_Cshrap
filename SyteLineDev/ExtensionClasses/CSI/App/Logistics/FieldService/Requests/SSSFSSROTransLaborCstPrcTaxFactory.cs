//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransLaborCstPrcTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransLaborCstPrcTaxFactory
	{
		public ISSSFSSROTransLaborCstPrcTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransLaborCstPrcTax = new Logistics.FieldService.Requests.SSSFSSROTransLaborCstPrcTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransLaborCstPrcTaxExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransLaborCstPrcTax>(_SSSFSSROTransLaborCstPrcTax);
			
			return iSSSFSSROTransLaborCstPrcTaxExt;
		}
	}
}
