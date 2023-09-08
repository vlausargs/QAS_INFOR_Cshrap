//PROJECT NAME: DataCollection
//CLASS NAME: DcAMiscirFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAMiscirFactory
	{
		public IDcAMiscir Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAMiscir = new DataCollection.DcAMiscir(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAMiscirExt = timerfactory.Create<DataCollection.IDcAMiscir>(_DcAMiscir);
			
			return iDcAMiscirExt;
		}
	}
}
