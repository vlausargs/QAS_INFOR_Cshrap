//PROJECT NAME: Production
//CLASS NAME: VerifyFromPrFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class VerifyFromPrFactory
	{
		public IVerifyFromPr Create(IApplicationDB appDB)
		{
			var _VerifyFromPr = new Production.Projects.VerifyFromPr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyFromPrExt = timerfactory.Create<Production.Projects.IVerifyFromPr>(_VerifyFromPr);
			
			return iVerifyFromPrExt;
		}
	}
}
