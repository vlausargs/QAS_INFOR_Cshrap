//PROJECT NAME: Material
//CLASS NAME: GetItemSerialPrefixFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetItemSerialPrefixFactory
	{
		public IGetItemSerialPrefix Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemSerialPrefix = new Material.GetItemSerialPrefix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemSerialPrefixExt = timerfactory.Create<Material.IGetItemSerialPrefix>(_GetItemSerialPrefix);
			
			return iGetItemSerialPrefixExt;
		}
	}
}
