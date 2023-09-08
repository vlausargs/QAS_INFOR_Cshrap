//PROJECT NAME: Production
//CLASS NAME: GeneratePackageSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class GeneratePackageSerialFactory
	{
		public IGeneratePackageSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GeneratePackageSerial = new Production.Quality.GeneratePackageSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePackageSerialExt = timerfactory.Create<Production.Quality.IGeneratePackageSerial>(_GeneratePackageSerial);
			
			return iGeneratePackageSerialExt;
		}
	}
}
