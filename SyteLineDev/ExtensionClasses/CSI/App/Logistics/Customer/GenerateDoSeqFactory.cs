//PROJECT NAME: Logistics
//CLASS NAME: GenerateDoSeqFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateDoSeqFactory
	{
		public IGenerateDoSeq Create(IApplicationDB appDB)
		{
			var _GenerateDoSeq = new Logistics.Customer.GenerateDoSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateDoSeqExt = timerfactory.Create<Logistics.Customer.IGenerateDoSeq>(_GenerateDoSeq);
			
			return iGenerateDoSeqExt;
		}
	}
}
