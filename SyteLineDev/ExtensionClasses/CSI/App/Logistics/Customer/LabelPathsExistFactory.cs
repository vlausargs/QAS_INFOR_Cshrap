//PROJECT NAME: CSICustomer
//CLASS NAME: LabelPathsExistFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LabelPathsExistFactory
	{
		public ILabelPathsExist Create(IApplicationDB appDB)
		{
			var _LabelPathsExist = new Logistics.Customer.LabelPathsExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLabelPathsExistExt = timerfactory.Create<Logistics.Customer.ILabelPathsExist>(_LabelPathsExist);
			
			return iLabelPathsExistExt;
		}
	}
}
