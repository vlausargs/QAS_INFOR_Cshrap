//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSInspectionsPreviewFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSInspectionsPreviewFactory
	{
		public ISSSFSInspectionsPreview Create(IApplicationDB appDB)
		{
			var _SSSFSInspectionsPreview = new Logistics.FieldService.SSSFSInspectionsPreview(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSInspectionsPreviewExt = timerfactory.Create<Logistics.FieldService.ISSSFSInspectionsPreview>(_SSSFSInspectionsPreview);
			
			return iSSSFSInspectionsPreviewExt;
		}
	}
}
