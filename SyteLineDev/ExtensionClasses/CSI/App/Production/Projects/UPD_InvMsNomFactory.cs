//PROJECT NAME: Production
//CLASS NAME: UPD_InvMsNomFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class UPD_InvMsNomFactory
	{
		public IUPD_InvMsNom Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UPD_InvMsNom = new Production.Projects.UPD_InvMsNom(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUPD_InvMsNomExt = timerfactory.Create<Production.Projects.IUPD_InvMsNom>(_UPD_InvMsNom);
			
			return iUPD_InvMsNomExt;
		}
	}
}
