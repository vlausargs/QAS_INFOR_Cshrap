//PROJECT NAME: Production
//CLASS NAME: GenerateTmpShipSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class GenerateTmpShipSeqFactory
	{
		public IGenerateTmpShipSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateTmpShipSeq = new Production.Quality.GenerateTmpShipSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateTmpShipSeqExt = timerfactory.Create<Production.Quality.IGenerateTmpShipSeq>(_GenerateTmpShipSeq);
			
			return iGenerateTmpShipSeqExt;
		}
	}
}
