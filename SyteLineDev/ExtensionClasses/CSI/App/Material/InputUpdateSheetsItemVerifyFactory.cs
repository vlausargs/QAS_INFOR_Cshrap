//PROJECT NAME: Material
//CLASS NAME: InputUpdateSheetsItemVerifyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InputUpdateSheetsItemVerifyFactory
	{
		public IInputUpdateSheetsItemVerify Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InputUpdateSheetsItemVerify = new Material.InputUpdateSheetsItemVerify(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInputUpdateSheetsItemVerifyExt = timerfactory.Create<Material.IInputUpdateSheetsItemVerify>(_InputUpdateSheetsItemVerify);
			
			return iInputUpdateSheetsItemVerifyExt;
		}
	}
}
