//PROJECT NAME: DataCollection
//CLASS NAME: DcAJobmatFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAJobmatFactory
	{
		public IDcAJobmat Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAJobmat = new DataCollection.DcAJobmat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAJobmatExt = timerfactory.Create<DataCollection.IDcAJobmat>(_DcAJobmat);
			
			return iDcAJobmatExt;
		}
	}
}
