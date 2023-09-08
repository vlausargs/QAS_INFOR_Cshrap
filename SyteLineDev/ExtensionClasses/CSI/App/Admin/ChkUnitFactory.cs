//PROJECT NAME: Admin
//CLASS NAME: ChkUnitFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class ChkUnitFactory
	{
		public IChkUnit Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ChkUnit = new Admin.ChkUnit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkUnitExt = timerfactory.Create<Admin.IChkUnit>(_ChkUnit);
			
			return iChkUnitExt;
		}
	}
}
