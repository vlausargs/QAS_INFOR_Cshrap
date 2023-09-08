//PROJECT NAME: Admin
//CLASS NAME: GetAdpParmFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class GetAdpParmFactory
	{
		public IGetAdpParm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetAdpParm = new Admin.GetAdpParm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAdpParmExt = timerfactory.Create<Admin.IGetAdpParm>(_GetAdpParm);
			
			return iGetAdpParmExt;
		}
	}
}
