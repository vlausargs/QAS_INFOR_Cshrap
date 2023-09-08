//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoSoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoSoFactory
	{
		public ICpSoCpSoSo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CpSoCpSoSo = new Logistics.Customer.CpSoCpSoSo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpSoCpSoSoExt = timerfactory.Create<Logistics.Customer.ICpSoCpSoSo>(_CpSoCpSoSo);
			
			return iCpSoCpSoSoExt;
		}
	}
}
