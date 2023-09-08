//PROJECT NAME: DataCollection
//CLASS NAME: DcPoValidateEmpNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcPoValidateEmpNumFactory
	{
		public IDcPoValidateEmpNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcPoValidateEmpNum = new DataCollection.DcPoValidateEmpNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcPoValidateEmpNumExt = timerfactory.Create<DataCollection.IDcPoValidateEmpNum>(_DcPoValidateEmpNum);
			
			return iDcPoValidateEmpNumExt;
		}
	}
}
