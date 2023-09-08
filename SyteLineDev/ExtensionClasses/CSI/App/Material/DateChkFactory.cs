//PROJECT NAME: Material
//CLASS NAME: DateChkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class DateChkFactory
	{
		public IDateChk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DateChk = new Material.DateChk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDateChkExt = timerfactory.Create<Material.IDateChk>(_DateChk);
			
			return iDateChkExt;
		}
	}
}
