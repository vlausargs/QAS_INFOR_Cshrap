//PROJECT NAME: Codes
//CLASS NAME: EFTMapCreateDataViewFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class EFTMapCreateDataViewFactory
	{
		public IEFTMapCreateDataView Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EFTMapCreateDataView = new Codes.EFTMapCreateDataView(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTMapCreateDataViewExt = timerfactory.Create<Codes.IEFTMapCreateDataView>(_EFTMapCreateDataView);
			
			return iEFTMapCreateDataViewExt;
		}
	}
}
