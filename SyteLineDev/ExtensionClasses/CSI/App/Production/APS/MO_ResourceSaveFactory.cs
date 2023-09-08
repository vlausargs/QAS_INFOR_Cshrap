//PROJECT NAME: Production
//CLASS NAME: MO_ResourceSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class MO_ResourceSaveFactory
	{
		public IMO_ResourceSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_ResourceSave = new Production.APS.MO_ResourceSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceSaveExt = timerfactory.Create<Production.APS.IMO_ResourceSave>(_MO_ResourceSave);
			
			return iMO_ResourceSaveExt;
		}
	}
}
