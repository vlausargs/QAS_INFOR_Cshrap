//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeTimeSheetDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBEmployeeTimeSheetDetailFactory
	{
		public ILoadESBEmployeeTimeSheetDetail Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBEmployeeTimeSheetDetail = new BusInterface.LoadESBEmployeeTimeSheetDetail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBEmployeeTimeSheetDetailExt = timerfactory.Create<BusInterface.ILoadESBEmployeeTimeSheetDetail>(_LoadESBEmployeeTimeSheetDetail);
			
			return iLoadESBEmployeeTimeSheetDetailExt;
		}
	}
}
