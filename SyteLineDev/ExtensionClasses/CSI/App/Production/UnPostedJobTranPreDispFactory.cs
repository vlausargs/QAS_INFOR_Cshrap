//PROJECT NAME: Production
//CLASS NAME: UnPostedJobTranPreDispFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class UnPostedJobTranPreDispFactory
	{
		public IUnPostedJobTranPreDisp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UnPostedJobTranPreDisp = new Production.UnPostedJobTranPreDisp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnPostedJobTranPreDispExt = timerfactory.Create<Production.IUnPostedJobTranPreDisp>(_UnPostedJobTranPreDisp);
			
			return iUnPostedJobTranPreDispExt;
		}
	}
}
