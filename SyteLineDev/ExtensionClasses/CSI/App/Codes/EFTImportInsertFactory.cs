//PROJECT NAME: CSICodes
//CLASS NAME: EFTImportInsertFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class EFTImportInsertFactory
	{
		public IEFTImportInsert Create(IApplicationDB appDB)
		{
			var _EFTImportInsert = new Codes.EFTImportInsert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTImportInsertExt = timerfactory.Create<Codes.IEFTImportInsert>(_EFTImportInsert);
			
			return iEFTImportInsertExt;
		}
	}
}
