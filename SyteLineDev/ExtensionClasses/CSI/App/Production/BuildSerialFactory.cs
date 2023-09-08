//PROJECT NAME: Production
//CLASS NAME: BuildSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class BuildSerialFactory
	{
		public IBuildSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BuildSerial = new Production.BuildSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBuildSerialExt = timerfactory.Create<Production.IBuildSerial>(_BuildSerial);
			
			return iBuildSerialExt;
		}
	}
}
