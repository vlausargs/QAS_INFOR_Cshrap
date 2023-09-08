//PROJECT NAME: Logistics
//CLASS NAME: GenerateUnpackInventoryTmpShipSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateUnpackInventoryTmpShipSeqFactory
	{
		public IGenerateUnpackInventoryTmpShipSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateUnpackInventoryTmpShipSeq = new Logistics.Customer.GenerateUnpackInventoryTmpShipSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateUnpackInventoryTmpShipSeqExt = timerfactory.Create<Logistics.Customer.IGenerateUnpackInventoryTmpShipSeq>(_GenerateUnpackInventoryTmpShipSeq);
			
			return iGenerateUnpackInventoryTmpShipSeqExt;
		}
	}
}
