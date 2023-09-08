//PROJECT NAME: Admin
//CLASS NAME: LoadActiveFeatureListFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class LoadActiveFeatureListFactory
	{
		public ILoadActiveFeatureList Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _LoadActiveFeatureList = new Admin.LoadActiveFeatureList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadActiveFeatureListExt = timerfactory.Create<Admin.ILoadActiveFeatureList>(_LoadActiveFeatureList);
			
			return iLoadActiveFeatureListExt;
		}
	}
}
