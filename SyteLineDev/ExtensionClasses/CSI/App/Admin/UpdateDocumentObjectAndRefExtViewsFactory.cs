//PROJECT NAME: Admin
//CLASS NAME: UpdateDocumentObjectAndRefExtViewsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class UpdateDocumentObjectAndRefExtViewsFactory
	{
		public IUpdateDocumentObjectAndRefExtViews Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateDocumentObjectAndRefExtViews = new Admin.UpdateDocumentObjectAndRefExtViews(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateDocumentObjectAndRefExtViewsExt = timerfactory.Create<Admin.IUpdateDocumentObjectAndRefExtViews>(_UpdateDocumentObjectAndRefExtViews);
			
			return iUpdateDocumentObjectAndRefExtViewsExt;
		}
	}
}
