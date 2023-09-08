//PROJECT NAME: Production
//CLASS NAME: CojobItemCopyBOMFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CojobItemCopyBOMFactory
	{
		public ICojobItemCopyBOM Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CojobItemCopyBOM = new Production.CojobItemCopyBOM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCojobItemCopyBOMExt = timerfactory.Create<Production.ICojobItemCopyBOM>(_CojobItemCopyBOM);
			
			return iCojobItemCopyBOMExt;
		}
	}
}
