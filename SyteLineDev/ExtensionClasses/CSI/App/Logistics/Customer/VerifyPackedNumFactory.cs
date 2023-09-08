//PROJECT NAME: Logistics
//CLASS NAME: VerifyPackedNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class VerifyPackedNumFactory
	{
		public IVerifyPackedNum Create(IApplicationDB appDB)
		{
			var _VerifyPackedNum = new Logistics.Customer.VerifyPackedNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyPackedNumExt = timerfactory.Create<Logistics.Customer.IVerifyPackedNum>(_VerifyPackedNum);
			
			return iVerifyPackedNumExt;
		}
	}
}
