//PROJECT NAME: Material
//CLASS NAME: NextSjbFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class NextSjbFactory
	{
		public INextSjb Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _NextSjb = new Production.NextSjb(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextSjbExt = timerfactory.Create<Production.INextSjb>(_NextSjb);

			return iNextSjbExt;
		}
	}
}
