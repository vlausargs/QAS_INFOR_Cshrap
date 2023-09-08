//PROJECT NAME: Production
//CLASS NAME: JobtPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtPFactory
	{
		public IJobtP Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _JobtP = new Production.JobtP(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtPExt = timerfactory.Create<Production.IJobtP>(_JobtP);

			return iJobtPExt;
		}
	}
}
