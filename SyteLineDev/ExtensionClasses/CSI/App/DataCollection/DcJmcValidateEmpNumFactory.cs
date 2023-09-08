//PROJECT NAME: DataCollection
//CLASS NAME: DcJmcValidateEmpNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcJmcValidateEmpNumFactory
	{
		public IDcJmcValidateEmpNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcJmcValidateEmpNum = new DataCollection.DcJmcValidateEmpNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcJmcValidateEmpNumExt = timerfactory.Create<DataCollection.IDcJmcValidateEmpNum>(_DcJmcValidateEmpNum);
			
			return iDcJmcValidateEmpNumExt;
		}
	}
}
