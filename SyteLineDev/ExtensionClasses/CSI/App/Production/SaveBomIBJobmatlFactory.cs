//PROJECT NAME: Production
//CLASS NAME: SaveBomIBJobmatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SaveBomIBJobmatlFactory
	{
		public ISaveBomIBJobmatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SaveBomIBJobmatl = new Production.SaveBomIBJobmatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveBomIBJobmatlExt = timerfactory.Create<Production.ISaveBomIBJobmatl>(_SaveBomIBJobmatl);
			
			return iSaveBomIBJobmatlExt;
		}
	}
}
