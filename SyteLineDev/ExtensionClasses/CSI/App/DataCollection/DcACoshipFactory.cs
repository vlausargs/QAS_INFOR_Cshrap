//PROJECT NAME: DataCollection
//CLASS NAME: DcACoshipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcACoshipFactory
	{
		public IDcACoship Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcACoship = new DataCollection.DcACoship(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcACoshipExt = timerfactory.Create<DataCollection.IDcACoship>(_DcACoship);
			
			return iDcACoshipExt;
		}
	}
}
