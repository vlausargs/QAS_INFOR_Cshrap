//PROJECT NAME: CSICodes
//CLASS NAME: EFTImportFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class EFTImportFactory
	{
		public IEFTImport Create(IApplicationDB appDB)
		{
			var _EFTImport = new Codes.EFTImport(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportExt = timerfactory.Create<Codes.IEFTImport>(_EFTImport);
			
			return iEFTImportExt;
		}
	}
}
