//PROJECT NAME: Production
//CLASS NAME: SernumJFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SernumJFactory
	{
		public ISernumJ Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _SernumJ = new Production.SernumJ(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSernumJExt = timerfactory.Create<Production.ISernumJ>(_SernumJ);

			return iSernumJExt;
		}
	}
}
