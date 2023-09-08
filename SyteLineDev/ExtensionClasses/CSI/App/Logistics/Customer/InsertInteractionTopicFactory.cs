//PROJECT NAME: CSICustomer
//CLASS NAME: InsertInteractionTopicFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InsertInteractionTopicFactory
	{
		public IInsertInteractionTopic Create(IApplicationDB appDB)
		{
			var _InsertInteractionTopic = new Logistics.Customer.InsertInteractionTopic(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertInteractionTopicExt = timerfactory.Create<Logistics.Customer.IInsertInteractionTopic>(_InsertInteractionTopic);
			
			return iInsertInteractionTopicExt;
		}
	}
}
