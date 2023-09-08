//PROJECT NAME: Production
//CLASS NAME: CheckWhseExternalControlledFlagFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckWhseExternalControlledFlagFactory
	{
		public ICheckWhseExternalControlledFlag Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _CheckWhseExternalControlledFlag = new Production.CheckWhseExternalControlledFlag(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckWhseExternalControlledFlagExt = timerfactory.Create<Production.ICheckWhseExternalControlledFlag>(_CheckWhseExternalControlledFlag);

			return iCheckWhseExternalControlledFlagExt;
		}
	}
}
