//PROJECT NAME: Logistics
//CLASS NAME: SequencePreSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SequencePreSaveFactory
	{
		public ISequencePreSave Create(IApplicationDB appDB)
		{
			var _SequencePreSave = new Logistics.Customer.SequencePreSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSequencePreSaveExt = timerfactory.Create<Logistics.Customer.ISequencePreSave>(_SequencePreSave);
			
			return iSequencePreSaveExt;
		}
	}
}
