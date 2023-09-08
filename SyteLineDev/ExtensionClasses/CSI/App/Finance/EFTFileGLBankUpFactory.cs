//PROJECT NAME: Finance
//CLASS NAME: EFTFileGLBankUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class EFTFileGLBankUpFactory
	{
		public IEFTFileGLBankUp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTFileGLBankUp = new Finance.EFTFileGLBankUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTFileGLBankUpExt = timerfactory.Create<Finance.IEFTFileGLBankUp>(_EFTFileGLBankUp);
			
			return iEFTFileGLBankUpExt;
		}
	}
}
