//PROJECT NAME: Admin
//CLASS NAME: SLPreciseSearchPreferenceListsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SLPreciseSearchPreferenceListsFactory
	{
		public ISLPreciseSearchPreferenceLists Create(IApplicationDB appDB)
		{
			var _SLPreciseSearchPreferenceLists = new Admin.SLPreciseSearchPreferenceLists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSLPreciseSearchPreferenceListsExt = timerfactory.Create<Admin.ISLPreciseSearchPreferenceLists>(_SLPreciseSearchPreferenceLists);
			
			return iSLPreciseSearchPreferenceListsExt;
		}
	}
}
