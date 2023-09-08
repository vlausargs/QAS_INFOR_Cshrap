//PROJECT NAME: Material
//CLASS NAME: GetBomSequenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetBomSequenceFactory
	{
		public IGetBomSequence Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetBomSequence = new Material.GetBomSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetBomSequenceExt = timerfactory.Create<Material.IGetBomSequence>(_GetBomSequence);
			
			return iGetBomSequenceExt;
		}
	}
}
