//PROJECT NAME: Finance
//CLASS NAME: CHSGetVoucherTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSGetVoucherTypeFactory
	{
		public ICHSGetVoucherType Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSGetVoucherType = new Finance.Chinese.CHSGetVoucherType(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGetVoucherTypeExt = timerfactory.Create<Finance.Chinese.ICHSGetVoucherType>(_CHSGetVoucherType);
			
			return iCHSGetVoucherTypeExt;
		}
	}
}
