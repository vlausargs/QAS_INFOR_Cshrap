//PROJECT NAME: Finance
//CLASS NAME: CHSRepAcctsReSequenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSRepAcctsReSequenceFactory
	{
		public ICHSRepAcctsReSequence Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSRepAcctsReSequence = new Finance.Chinese.CHSRepAcctsReSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRepAcctsReSequenceExt = timerfactory.Create<Finance.Chinese.ICHSRepAcctsReSequence>(_CHSRepAcctsReSequence);
			
			return iCHSRepAcctsReSequenceExt;
		}
	}
}
