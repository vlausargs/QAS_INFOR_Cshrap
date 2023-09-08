//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSInspects.cs

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
	[IDOExtensionClass("FSInspects")]
	public class FSInspects : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSInspectionsCopySp(string FromItem,
		                                  string FromInspectType,
		                                  string FromSectionCode,
		                                  string ToItem,
		                                  string ToInspectType,
		                                  string ToSectionCode,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSInspectionsCopyExt = new SSSFSInspectionsCopyFactory().Create(appDb);
				
				int Severity = iSSSFSInspectionsCopyExt.SSSFSInspectionsCopySp(FromItem,
				                                                               FromInspectType,
				                                                               FromSectionCode,
				                                                               ToItem,
				                                                               ToInspectType,
				                                                               ToSectionCode,
				                                                               ref Infobar);
				
				return Severity;
			}
		}
	}
}
