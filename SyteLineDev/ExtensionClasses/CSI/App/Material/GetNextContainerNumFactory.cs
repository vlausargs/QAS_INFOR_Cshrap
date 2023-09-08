//PROJECT NAME: CSIMaterial
//CLASS NAME: GetNextContainerNumFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetNextContainerNumFactory
	{
		public IGetNextContainerNum Create(IApplicationDB appDB)
		{
			var _GetNextContainerNum = new Material.GetNextContainerNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextContainerNumExt = timerfactory.Create<Material.IGetNextContainerNum>(_GetNextContainerNum);
			
			return iGetNextContainerNumExt;
		}
	}
}
