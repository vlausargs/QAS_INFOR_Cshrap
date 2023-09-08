//PROJECT NAME: CSIRSQCS
//CLASS NAME: PackConfirmationCompleteFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class PackConfirmationCompleteFactory
	{
		public IPackConfirmationComplete Create(IApplicationDB appDB)
		{
			var _PackConfirmationComplete = new Production.Quality.PackConfirmationComplete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPackConfirmationCompleteExt = timerfactory.Create<Production.Quality.IPackConfirmationComplete>(_PackConfirmationComplete);
			
			return iPackConfirmationCompleteExt;
		}
	}
}
