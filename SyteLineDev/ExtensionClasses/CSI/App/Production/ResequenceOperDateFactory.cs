//PROJECT NAME: Production
//CLASS NAME: ResequenceOperDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ResequenceOperDateFactory
	{
		public IResequenceOperDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ResequenceOperDate = new Production.ResequenceOperDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iResequenceOperDateExt = timerfactory.Create<Production.IResequenceOperDate>(_ResequenceOperDate);
			
			return iResequenceOperDateExt;
		}
	}
}
