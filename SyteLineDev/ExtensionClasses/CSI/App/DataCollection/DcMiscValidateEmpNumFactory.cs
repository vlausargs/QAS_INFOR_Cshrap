//PROJECT NAME: DataCollection
//CLASS NAME: DcMiscValidateEmpNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcMiscValidateEmpNumFactory
	{
		public IDcMiscValidateEmpNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcMiscValidateEmpNum = new DataCollection.DcMiscValidateEmpNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcMiscValidateEmpNumExt = timerfactory.Create<DataCollection.IDcMiscValidateEmpNum>(_DcMiscValidateEmpNum);
			
			return iDcMiscValidateEmpNumExt;
		}
	}
}
