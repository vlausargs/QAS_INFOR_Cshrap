//PROJECT NAME: Logistics
//CLASS NAME: UnpickPickListProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpickPickListProcessFactory
	{
		public IUnpickPickListProcess Create(IApplicationDB appDB)
		{
			var _UnpickPickListProcess = new Logistics.Customer.UnpickPickListProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnpickPickListProcessExt = timerfactory.Create<Logistics.Customer.IUnpickPickListProcess>(_UnpickPickListProcess);
			
			return iUnpickPickListProcessExt;
		}
	}
}
