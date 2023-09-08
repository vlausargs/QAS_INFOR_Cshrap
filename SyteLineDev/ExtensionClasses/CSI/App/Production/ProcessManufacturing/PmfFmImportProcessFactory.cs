//PROJECT NAME: Production
//CLASS NAME: PmfFmImportProcessFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmImportProcessFactory
	{
		public IPmfFmImportProcess Create(IApplicationDB appDB)
		{
			var _PmfFmImportProcess = new Production.ProcessManufacturing.PmfFmImportProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmImportProcessExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmImportProcess>(_PmfFmImportProcess);
			
			return iPmfFmImportProcessExt;
		}
	}
}
