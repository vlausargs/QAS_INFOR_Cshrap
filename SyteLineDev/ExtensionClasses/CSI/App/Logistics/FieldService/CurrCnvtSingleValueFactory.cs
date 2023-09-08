//PROJECT NAME: Logistics
//CLASS NAME: CurrCnvtSingleValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class CurrCnvtSingleValueFactory
	{
		public ICurrCnvtSingleValue Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrCnvtSingleValue = new Logistics.FieldService.CurrCnvtSingleValue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrCnvtSingleValueExt = timerfactory.Create<Logistics.FieldService.ICurrCnvtSingleValue>(_CurrCnvtSingleValue);
			
			return iCurrCnvtSingleValueExt;
		}
	}
}
