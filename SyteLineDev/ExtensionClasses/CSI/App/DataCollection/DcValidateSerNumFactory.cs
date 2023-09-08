//PROJECT NAME: DataCollection
//CLASS NAME: DcValidateSerNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcValidateSerNumFactory
	{
		public IDcValidateSerNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcValidateSerNum = new DataCollection.DcValidateSerNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcValidateSerNumExt = timerfactory.Create<DataCollection.IDcValidateSerNum>(_DcValidateSerNum);
			
			return iDcValidateSerNumExt;
		}
	}
}
