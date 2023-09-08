//PROJECT NAME: Production
//CLASS NAME: prjresMatlQtyConvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class prjresMatlQtyConvFactory
	{
		public IprjresMatlQtyConv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _prjresMatlQtyConv = new Production.Projects.prjresMatlQtyConv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iprjresMatlQtyConvExt = timerfactory.Create<Production.Projects.IprjresMatlQtyConv>(_prjresMatlQtyConv);
			
			return iprjresMatlQtyConvExt;
		}
	}
}
