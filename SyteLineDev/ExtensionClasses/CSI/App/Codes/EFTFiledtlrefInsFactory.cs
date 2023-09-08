//PROJECT NAME: CSICodes
//CLASS NAME: EFTFiledtlrefInsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class EFTFiledtlrefInsFactory
	{
		public IEFTFiledtlrefIns Create(IApplicationDB appDB)
		{
			var _EFTFiledtlrefIns = new Codes.EFTFiledtlrefIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTFiledtlrefInsExt = timerfactory.Create<Codes.IEFTFiledtlrefIns>(_EFTFiledtlrefIns);
			
			return iEFTFiledtlrefInsExt;
		}
	}
}
