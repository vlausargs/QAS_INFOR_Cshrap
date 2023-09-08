//PROJECT NAME: Admin
//CLASS NAME: GetFormsStringTranslationFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class GetFormsStringTranslationFactory
	{
		public IGetFormsStringTranslation Create(IApplicationDB appDB)
		{
			var _GetFormsStringTranslation = new Admin.GetFormsStringTranslation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFormsStringTranslationExt = timerfactory.Create<Admin.IGetFormsStringTranslation>(_GetFormsStringTranslation);
			
			return iGetFormsStringTranslationExt;
		}
	}
}
