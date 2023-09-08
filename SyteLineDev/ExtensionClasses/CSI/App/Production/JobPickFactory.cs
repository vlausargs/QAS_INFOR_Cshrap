//PROJECT NAME: Production
//CLASS NAME: JobPickFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobPickFactory
	{
		public IJobPick Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _JobPick = new Production.JobPick(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobPickExt = timerfactory.Create<Production.IJobPick>(_JobPick);

			return iJobPickExt;
		}
	}
}
