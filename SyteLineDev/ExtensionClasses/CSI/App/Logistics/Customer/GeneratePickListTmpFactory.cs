//PROJECT NAME: Logistics
//CLASS NAME: GeneratePickListTmpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GeneratePickListTmpFactory
	{
		public IGeneratePickListTmp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GeneratePickListTmp = new Logistics.Customer.GeneratePickListTmp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePickListTmpExt = timerfactory.Create<Logistics.Customer.IGeneratePickListTmp>(_GeneratePickListTmp);
			
			return iGeneratePickListTmpExt;
		}
	}
}
