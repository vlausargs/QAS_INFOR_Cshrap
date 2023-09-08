//PROJECT NAME: NonTrans
//CLASS NAME: CreateAlternativeFactory.cs

using CSI.MG;

namespace CSI.NonTrans
{
	public class CreateAlternativeFactory
	{
		public ICreateAlternative Create(IApplicationDB appDB)
		{
			var _CreateAlternative = new NonTrans.CreateAlternative(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateAlternativeExt = timerfactory.Create<NonTrans.ICreateAlternative>(_CreateAlternative);
			
			return iCreateAlternativeExt;
		}
	}
}
