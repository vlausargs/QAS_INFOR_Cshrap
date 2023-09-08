//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSTmpSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSTmpSchedules")]
    public class FSTmpSchedules : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSMultiDayScheduleClearSp(Guid? SessionID, ref string Infobar)
		{
			var iSSSFSMultiDayScheduleClearExt = new SSSFSMultiDayScheduleClearFactory().Create(this, true);
			
			var result = iSSSFSMultiDayScheduleClearExt.SSSFSMultiDayScheduleClearSp(SessionID, Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSMultiDaySchedulePostSp(Guid? SessionID,
		                                       byte? View,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSMultiDaySchedulePostExt = new SSSFSMultiDaySchedulePostFactory().Create(appDb);
				
				int Severity = iSSSFSMultiDaySchedulePostExt.SSSFSMultiDaySchedulePostSp(SessionID,
				                                                                         View,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSMultiDayScheduleLoadSp(Guid? SessionID,
		DateTime? SchedDate,
		decimal? Hrs,
		string Description,
		string RefType,
		string RefNum,
		int? RefLine,
		int? RefRel,
		int? RefSeq,
		string PartnerId,
		string SubId,
		string ApptType,
		string ApptStat,
		decimal? MinHours,
		decimal? MaxHours,
		int? Method,
		string NoteDesc,
		string NoteContent,
		string ScheduleID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSMultiDayScheduleLoadExt = new SSSFSMultiDayScheduleLoadFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSMultiDayScheduleLoadExt.SSSFSMultiDayScheduleLoadSp(SessionID,
				SchedDate,
				Hrs,
				Description,
				RefType,
				RefNum,
				RefLine,
				RefRel,
				RefSeq,
				PartnerId,
				SubId,
				ApptType,
				ApptStat,
				MinHours,
				MaxHours,
				Method,
				NoteDesc,
				NoteContent,
				ScheduleID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
