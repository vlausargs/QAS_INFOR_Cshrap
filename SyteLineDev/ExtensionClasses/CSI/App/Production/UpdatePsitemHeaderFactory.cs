//PROJECT NAME: Production
//CLASS NAME: UpdatePsitemHeaderFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class UpdatePsitemHeaderFactory
	{
		public IUpdatePsitemHeader Create(IApplicationDB appDB)
		{
			var _UpdatePsitemHeader = new Production.UpdatePsitemHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePsitemHeaderExt = timerfactory.Create<Production.IUpdatePsitemHeader>(_UpdatePsitemHeader);
			
			return iUpdatePsitemHeaderExt;
		}
	}
}
