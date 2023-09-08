//PROJECT NAME: CSIProjects
//CLASS NAME: UpdateAutoNominateInvoiceFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class UpdateAutoNominateInvoiceFactory
	{
		public IUpdateAutoNominateInvoice Create(IApplicationDB appDB)
		{
			var _UpdateAutoNominateInvoice = new Production.Projects.UpdateAutoNominateInvoice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateAutoNominateInvoiceExt = timerfactory.Create<Production.Projects.IUpdateAutoNominateInvoice>(_UpdateAutoNominateInvoice);
			
			return iUpdateAutoNominateInvoiceExt;
		}
	}
}
