//PROJECT NAME: CSIProduct
//CLASS NAME: ExpandValidateRplJobFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ExpandValidateRplJobFactory
	{
		public IExpandValidateRplJob Create(IApplicationDB appDB)
		{
			var _ExpandValidateRplJob = new Production.ExpandValidateRplJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExpandValidateRplJobExt = timerfactory.Create<Production.IExpandValidateRplJob>(_ExpandValidateRplJob);
			
			return iExpandValidateRplJobExt;
		}
	}
}
