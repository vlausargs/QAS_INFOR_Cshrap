//PROJECT NAME: DataCollection
//CLASS NAME: DcBGTaskCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcBGTaskCheckFactory
	{
		public IDcBGTaskCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcBGTaskCheck = new DataCollection.DcBGTaskCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcBGTaskCheckExt = timerfactory.Create<DataCollection.IDcBGTaskCheck>(_DcBGTaskCheck);
			
			return iDcBGTaskCheckExt;
		}
	}
}
