//PROJECT NAME: Logistics
//CLASS NAME: ConvertPoReqPreProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ConvertPoReqPreProcessFactory
	{
		public IConvertPoReqPreProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ConvertPoReqPreProcess = new Logistics.Vendor.ConvertPoReqPreProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iConvertPoReqPreProcessExt = timerfactory.Create<Logistics.Vendor.IConvertPoReqPreProcess>(_ConvertPoReqPreProcess);
			
			return iConvertPoReqPreProcessExt;
		}
	}
}
