//PROJECT NAME: CSIProduct
//CLASS NAME: JobReceiptPostSetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobReceiptPostSetVarsFactory
	{
		public IJobReceiptPostSetVars Create(IApplicationDB appDB)
		{
			var _JobReceiptPostSetVars = new Production.JobReceiptPostSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobReceiptPostSetVarsExt = timerfactory.Create<Production.IJobReceiptPostSetVars>(_JobReceiptPostSetVars);
			
			return iJobReceiptPostSetVarsExt;
		}
	}
}
