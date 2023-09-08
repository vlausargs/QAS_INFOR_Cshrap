//PROJECT NAME: DataCollection
//CLASS NAME: WcLbrDcValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class WcLbrDcValidateFactory
	{
		public IWcLbrDcValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WcLbrDcValidate = new DataCollection.WcLbrDcValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWcLbrDcValidateExt = timerfactory.Create<DataCollection.IWcLbrDcValidate>(_WcLbrDcValidate);
			
			return iWcLbrDcValidateExt;
		}
	}
}
