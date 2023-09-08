//PROJECT NAME: Production
//CLASS NAME: UpdateMaterialSequenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class UpdateMaterialSequenceFactory
	{
		public IUpdateMaterialSequence Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateMaterialSequence = new Production.UpdateMaterialSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateMaterialSequenceExt = timerfactory.Create<Production.IUpdateMaterialSequence>(_UpdateMaterialSequence);
			
			return iUpdateMaterialSequenceExt;
		}
	}
}
