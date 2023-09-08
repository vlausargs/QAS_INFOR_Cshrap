//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSTmpInspects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSTmpInspects")]
	public class FSTmpInspects : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSInspectionsPreviewCleanupSp()
		{
			var iSSSFSInspectionsPreviewCleanupExt = new SSSFSInspectionsPreviewCleanupFactory().Create(this, true);
			
			var result = iSSSFSInspectionsPreviewCleanupExt.SSSFSInspectionsPreviewCleanupSp();
			
			
			return result??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSInspectionsPreviewSp(string Item,
		                                     string InspectType,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSInspectionsPreviewExt = new SSSFSInspectionsPreviewFactory().Create(appDb);
				
				int Severity = iSSSFSInspectionsPreviewExt.SSSFSInspectionsPreviewSp(Item,
				                                                                     InspectType,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}
	}
}
