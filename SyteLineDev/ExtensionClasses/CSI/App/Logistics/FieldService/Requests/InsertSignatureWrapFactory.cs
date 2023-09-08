//PROJECT NAME: Logistics
//CLASS NAME: InsertSignatureWrapFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class InsertSignatureWrapFactory
	{
		public IInsertSignatureWrap Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertSignatureWrap = new Logistics.FieldService.Requests.InsertSignatureWrap(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertSignatureWrapExt = timerfactory.Create<Logistics.FieldService.Requests.IInsertSignatureWrap>(_InsertSignatureWrap);
			
			return iInsertSignatureWrapExt;
		}
	}
}
