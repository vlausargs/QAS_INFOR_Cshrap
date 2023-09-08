//PROJECT NAME: CSICodes
//CLASS NAME: CheckListSourceFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CheckListSourceFactory
	{
		public ICheckListSource Create(IApplicationDB appDB)
		{
			var _CheckListSource = new Codes.CheckListSource(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckListSourceExt = timerfactory.Create<Codes.ICheckListSource>(_CheckListSource);
			
			return iCheckListSourceExt;
		}
	}
}
