//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPersonnelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBPersonnelFactory
	{
		public ILoadESBPersonnel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBPersonnel = new BusInterface.LoadESBPersonnel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPersonnelExt = timerfactory.Create<BusInterface.ILoadESBPersonnel>(_LoadESBPersonnel);
			
			return iLoadESBPersonnelExt;
		}
	}
}
