//PROJECT NAME: Production
//CLASS NAME: JobtranPostMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranPostMatlFactory
	{
		public IJobtranPostMatl Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _JobtranPostMatl = new Production.JobtranPostMatl(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranPostMatlExt = timerfactory.Create<Production.IJobtranPostMatl>(_JobtranPostMatl);

			return iJobtranPostMatlExt;
		}
	}
}
