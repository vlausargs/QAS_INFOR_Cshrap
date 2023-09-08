//PROJECT NAME: Production
//CLASS NAME: CopyJobMaterialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CopyJobMaterialFactory
	{
		public ICopyJobMaterial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CopyJobMaterial = new Production.CopyJobMaterial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyJobMaterialExt = timerfactory.Create<Production.ICopyJobMaterial>(_CopyJobMaterial);
			
			return iCopyJobMaterialExt;
		}
	}
}
