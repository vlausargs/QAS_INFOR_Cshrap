//PROJECT NAME: DataCollection
//CLASS NAME: DcmoveValidateEmpNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcmoveValidateEmpNumFactory
	{
		public IDcmoveValidateEmpNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcmoveValidateEmpNum = new DataCollection.DcmoveValidateEmpNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmoveValidateEmpNumExt = timerfactory.Create<DataCollection.IDcmoveValidateEmpNum>(_DcmoveValidateEmpNum);
			
			return iDcmoveValidateEmpNumExt;
		}
	}
}
