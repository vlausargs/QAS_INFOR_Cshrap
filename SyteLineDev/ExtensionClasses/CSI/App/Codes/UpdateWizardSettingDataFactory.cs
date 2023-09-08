//PROJECT NAME: Codes
//CLASS NAME: UpdateWizardSettingDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class UpdateWizardSettingDataFactory
	{
		public IUpdateWizardSettingData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateWizardSettingData = new Codes.UpdateWizardSettingData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateWizardSettingDataExt = timerfactory.Create<Codes.IUpdateWizardSettingData>(_UpdateWizardSettingData);
			
			return iUpdateWizardSettingDataExt;
		}
	}
}
