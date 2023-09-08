//PROJECT NAME: Production
//CLASS NAME: SaveBomIBCleanUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SaveBomIBCleanUpFactory
	{
		public ISaveBomIBCleanUp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SaveBomIBCleanUp = new Production.SaveBomIBCleanUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveBomIBCleanUpExt = timerfactory.Create<Production.ISaveBomIBCleanUp>(_SaveBomIBCleanUp);
			
			return iSaveBomIBCleanUpExt;
		}
	}
}
