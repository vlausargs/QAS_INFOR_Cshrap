//PROJECT NAME: Material
//CLASS NAME: ExpandKyByTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ExpandKyByTypeFactory : IExpandKyByTypeFactory
	{
		public IExpandKyByType Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ExpandKyByType = new Material.ExpandKyByType(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExpandKyByTypeExt = timerfactory.Create<Material.IExpandKyByType>(_ExpandKyByType);

			return iExpandKyByTypeExt;
		}
        public IExpandKyByType Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ExpandKyByType = new ExpandKyByType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iExpandKyByTypeExt = timerfactory.Create<IExpandKyByType>(_ExpandKyByType);

            return iExpandKyByTypeExt;
        }
    }
}
