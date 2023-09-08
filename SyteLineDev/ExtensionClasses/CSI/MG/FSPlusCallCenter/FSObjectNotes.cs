//PROJECT NAME: FSPlusCallCenterExt
//CLASS NAME: FSObjectNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.CallCenter;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusCallCenter
{
	[IDOExtensionClass("FSObjectNotes")]
	public class FSObjectNotes : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedApptNotesPostSaveSp(byte? Response,
		                                         byte? NewAppt,
		                                         Guid? ApptRowPtr,
		                                         Guid? ApptParentRowPtr)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedApptNotesPostSaveExt = new SSSFSSchedApptNotesPostSaveFactory().Create(appDb);
				
				int Severity = iSSSFSSchedApptNotesPostSaveExt.SSSFSSchedApptNotesPostSaveSp(Response,
				                                                                             NewAppt,
				                                                                             ApptRowPtr,
				                                                                             ApptParentRowPtr);
				
				return Severity;
			}
		}
	}
}
