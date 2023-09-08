//PROJECT NAME: DataCollection
//CLASS NAME: GetDcparmAutopostEscFlagFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class GetDcparmAutopostEscFlagFactory
	{
		public IGetDcparmAutopostEscFlag Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDcparmAutopostEscFlag = new DataCollection.GetDcparmAutopostEscFlag(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDcparmAutopostEscFlagExt = timerfactory.Create<DataCollection.IGetDcparmAutopostEscFlag>(_GetDcparmAutopostEscFlag);
			
			return iGetDcparmAutopostEscFlagExt;
		}
	}
}
