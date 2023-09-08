//PROJECT NAME: Production
//CLASS NAME: PmfFmImportValidateFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmImportValidateFactory
	{
		public IPmfFmImportValidate Create(IApplicationDB appDB)
		{
			var _PmfFmImportValidate = new Production.ProcessManufacturing.PmfFmImportValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmImportValidateExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmImportValidate>(_PmfFmImportValidate);
			
			return iPmfFmImportValidateExt;
		}
	}
}
