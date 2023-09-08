//PROJECT NAME: DataCollection
//CLASS NAME: DcCoValidateEmpNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcCoValidateEmpNumFactory
	{
		public IDcCoValidateEmpNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcCoValidateEmpNum = new DataCollection.DcCoValidateEmpNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcCoValidateEmpNumExt = timerfactory.Create<DataCollection.IDcCoValidateEmpNum>(_DcCoValidateEmpNum);
			
			return iDcCoValidateEmpNumExt;
		}
	}
}
