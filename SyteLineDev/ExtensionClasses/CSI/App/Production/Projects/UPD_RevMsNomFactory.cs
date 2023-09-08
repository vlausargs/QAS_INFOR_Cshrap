//PROJECT NAME: Production
//CLASS NAME: UPD_RevMsNomFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class UPD_RevMsNomFactory
	{
		public IUPD_RevMsNom Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UPD_RevMsNom = new Production.Projects.UPD_RevMsNom(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUPD_RevMsNomExt = timerfactory.Create<Production.Projects.IUPD_RevMsNom>(_UPD_RevMsNom);
			
			return iUPD_RevMsNomExt;
		}
	}
}
