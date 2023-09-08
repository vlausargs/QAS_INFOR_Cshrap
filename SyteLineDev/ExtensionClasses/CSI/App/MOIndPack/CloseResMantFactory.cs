//PROJECT NAME: CSIMOIndPack
//CLASS NAME: CloseResMantFactory.cs

using CSI.MG;

namespace CSI.MOIndPack
{
	public class CloseResMantFactory
	{
		public ICloseResMant Create(IApplicationDB appDB)
		{
			var _CloseResMant = new MOIndPack.CloseResMant(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCloseResMantExt = timerfactory.Create<MOIndPack.ICloseResMant>(_CloseResMant);
			
			return iCloseResMantExt;
		}
	}
}
