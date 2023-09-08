//PROJECT NAME: DataCollection
//CLASS NAME: DcmovePostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcmovePostFactory
	{
		public IDcmovePost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcmovePost = new DataCollection.DcmovePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmovePostExt = timerfactory.Create<DataCollection.IDcmovePost>(_DcmovePost);
			
			return iDcmovePostExt;
		}
	}
}
