//PROJECT NAME: DataCollection
//CLASS NAME: DcAJobrcvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAJobrcvFactory
	{
		public IDcAJobrcv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAJobrcv = new DataCollection.DcAJobrcv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAJobrcvExt = timerfactory.Create<DataCollection.IDcAJobrcv>(_DcAJobrcv);
			
			return iDcAJobrcvExt;
		}
	}
}
