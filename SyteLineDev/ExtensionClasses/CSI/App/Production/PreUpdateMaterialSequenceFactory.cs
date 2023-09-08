//PROJECT NAME: Production
//CLASS NAME: PreUpdateMaterialSequenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PreUpdateMaterialSequenceFactory
	{
		public IPreUpdateMaterialSequence Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreUpdateMaterialSequence = new Production.PreUpdateMaterialSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreUpdateMaterialSequenceExt = timerfactory.Create<Production.IPreUpdateMaterialSequence>(_PreUpdateMaterialSequence);
			
			return iPreUpdateMaterialSequenceExt;
		}
	}
}
