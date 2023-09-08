//PROJECT NAME: DataCollection
//CLASS NAME: DcATransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcATransFactory
	{
		public IDcATrans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcATrans = new DataCollection.DcATrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcATransExt = timerfactory.Create<DataCollection.IDcATrans>(_DcATrans);
			
			return iDcATransExt;
		}
	}
}
