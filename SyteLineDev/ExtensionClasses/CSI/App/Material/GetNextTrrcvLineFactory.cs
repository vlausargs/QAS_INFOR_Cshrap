//PROJECT NAME: Material
//CLASS NAME: GetNextTrrcvLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetNextTrrcvLineFactory
	{
		public IGetNextTrrcvLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextTrrcvLine = new Material.GetNextTrrcvLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextTrrcvLineExt = timerfactory.Create<Material.IGetNextTrrcvLine>(_GetNextTrrcvLine);
			
			return iGetNextTrrcvLineExt;
		}
	}
}
