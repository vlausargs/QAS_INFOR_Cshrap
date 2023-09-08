//PROJECT NAME: Production
//CLASS NAME: MO_NextAlternateSuffixFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class MO_NextAlternateSuffixFactory
	{
		public IMO_NextAlternateSuffix Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_NextAlternateSuffix = new Production.MO_NextAlternateSuffix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_NextAlternateSuffixExt = timerfactory.Create<Production.IMO_NextAlternateSuffix>(_MO_NextAlternateSuffix);
			
			return iMO_NextAlternateSuffixExt;
		}
	}
}
