//PROJECT NAME: Production
//CLASS NAME: CoProductSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CoProductSaveFactory
	{
		public ICoProductSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoProductSave = new Production.CoProductSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoProductSaveExt = timerfactory.Create<Production.ICoProductSave>(_CoProductSave);
			
			return iCoProductSaveExt;
		}
	}
}
