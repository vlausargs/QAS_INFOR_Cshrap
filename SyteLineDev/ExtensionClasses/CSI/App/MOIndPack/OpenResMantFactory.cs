//PROJECT NAME: CSIMOIndPack
//CLASS NAME: OpenResMantFactory.cs

using CSI.MG;

namespace CSI.MOIndPack
{
	public class OpenResMantFactory
	{
		public IOpenResMant Create(IApplicationDB appDB)
		{
			var _OpenResMant = new MOIndPack.OpenResMant(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOpenResMantExt = timerfactory.Create<MOIndPack.IOpenResMant>(_OpenResMant);
			
			return iOpenResMantExt;
		}
	}
}
