//PROJECT NAME: DataCollection
//CLASS NAME: GetDcparmAutopostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class GetDcparmAutopostFactory
	{
		public IGetDcparmAutopost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDcparmAutopost = new DataCollection.GetDcparmAutopost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDcparmAutopostExt = timerfactory.Create<DataCollection.IGetDcparmAutopost>(_GetDcparmAutopost);
			
			return iGetDcparmAutopostExt;
		}
	}
}
