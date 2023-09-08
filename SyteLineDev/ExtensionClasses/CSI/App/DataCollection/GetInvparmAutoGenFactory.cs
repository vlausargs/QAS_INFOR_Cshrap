//PROJECT NAME: DataCollection
//CLASS NAME: GetInvparmAutoGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class GetInvparmAutoGenFactory
	{
		public IGetInvparmAutoGen Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetInvparmAutoGen = new DataCollection.GetInvparmAutoGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInvparmAutoGenExt = timerfactory.Create<DataCollection.IGetInvparmAutoGen>(_GetInvparmAutoGen);
			
			return iGetInvparmAutoGenExt;
		}
	}
}
