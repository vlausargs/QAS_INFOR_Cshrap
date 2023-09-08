//PROJECT NAME: Material
//CLASS NAME: MtCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MtCodeFactory
	{
		public IMtCode Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _MtCode = new Material.MtCode(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMtCodeExt = timerfactory.Create<Material.IMtCode>(_MtCode);

			return iMtCodeExt;
		}
	}
}
