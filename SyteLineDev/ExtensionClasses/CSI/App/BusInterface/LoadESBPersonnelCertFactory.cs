//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnelCertFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBPersonnelCertFactory
	{
		public ILoadESBPersonnelCert Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBPersonnelCert = new BusInterface.LoadESBPersonnelCert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPersonnelCertExt = timerfactory.Create<BusInterface.ILoadESBPersonnelCert>(_LoadESBPersonnelCert);
			
			return iLoadESBPersonnelCertExt;
		}
	}
}
