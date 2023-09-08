//PROJECT NAME: Logistics
//CLASS NAME: ArtranUpdRemCallFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArtranUpdRemCallFactory
	{
		public IArtranUpdRemCall Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArtranUpdRemCall = new Logistics.Customer.ArtranUpdRemCall(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArtranUpdRemCallExt = timerfactory.Create<Logistics.Customer.IArtranUpdRemCall>(_ArtranUpdRemCall);
			
			return iArtranUpdRemCallExt;
		}
	}
}
