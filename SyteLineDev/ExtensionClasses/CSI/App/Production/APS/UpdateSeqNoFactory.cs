//PROJECT NAME: Production
//CLASS NAME: UpdateSeqNoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class UpdateSeqNoFactory
	{
		public IUpdateSeqNo Create(IApplicationDB appDB)
		{
			var _UpdateSeqNo = new Production.APS.UpdateSeqNo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateSeqNoExt = timerfactory.Create<Production.APS.IUpdateSeqNo>(_UpdateSeqNo);
			
			return iUpdateSeqNoExt;
		}
	}
}
