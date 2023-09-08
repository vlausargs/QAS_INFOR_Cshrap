//PROJECT NAME: CSICodes
//CLASS NAME: EFTFileDtlUpFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class EFTFileDtlUpFactory
	{
		public IEFTFileDtlUp Create(IApplicationDB appDB)
		{
			var _EFTFileDtlUp = new Codes.EFTFileDtlUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTFileDtlUpExt = timerfactory.Create<Codes.IEFTFileDtlUp>(_EFTFileDtlUp);
			
			return iEFTFileDtlUpExt;
		}
	}
}
