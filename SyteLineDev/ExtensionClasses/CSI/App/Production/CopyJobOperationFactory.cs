//PROJECT NAME: CSIProduct
//CLASS NAME: CopyJobOperationFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyJobOperationFactory
	{
		public ICopyJobOperation Create(IApplicationDB appDB)
		{
			var _CopyJobOperation = new Production.CopyJobOperation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyJobOperationExt = timerfactory.Create<Production.ICopyJobOperation>(_CopyJobOperation);
			
			return iCopyJobOperationExt;
		}
	}
}
