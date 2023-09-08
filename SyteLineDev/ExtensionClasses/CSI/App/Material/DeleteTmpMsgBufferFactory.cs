//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteTmpMsgBufferFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class DeleteTmpMsgBufferFactory
	{
		public IDeleteTmpMsgBuffer Create(IApplicationDB appDB)
		{
			var _DeleteTmpMsgBuffer = new Material.DeleteTmpMsgBuffer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTmpMsgBufferExt = timerfactory.Create<Material.IDeleteTmpMsgBuffer>(_DeleteTmpMsgBuffer);
			
			return iDeleteTmpMsgBufferExt;
		}
	}
}
