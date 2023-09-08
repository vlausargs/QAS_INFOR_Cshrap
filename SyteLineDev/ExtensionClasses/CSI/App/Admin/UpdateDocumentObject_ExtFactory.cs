//PROJECT NAME: Admin
//CLASS NAME: UpdateDocumentObject_ExtFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class UpdateDocumentObject_ExtFactory
	{
		public IUpdateDocumentObject_Ext Create(IApplicationDB appDB)
		{
			var _UpdateDocumentObject_Ext = new Admin.UpdateDocumentObject_Ext(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateDocumentObject_ExtExt = timerfactory.Create<Admin.IUpdateDocumentObject_Ext>(_UpdateDocumentObject_Ext);
			
			return iUpdateDocumentObject_ExtExt;
		}
	}
}
