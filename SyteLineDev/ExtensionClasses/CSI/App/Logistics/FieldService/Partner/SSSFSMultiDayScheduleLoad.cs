//PROJECT NAME: Logistics
//CLASS NAME: SSSFSMultiDayScheduleLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSMultiDayScheduleLoad : ISSSFSMultiDayScheduleLoad
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSMultiDayScheduleLoad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSMultiDayScheduleLoadSp(Guid? SessionID,
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
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			DateType _SchedDate = SchedDate;
			QtyUnitType _Hrs = Hrs;
			DescriptionType _Description = Description;
			FSRefTypeJKNSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLine = RefLine;
			FSRefReleaseType _RefRel = RefRel;
			FSRefSeqType _RefSeq = RefSeq;
			FSPartnerType _PartnerId = PartnerId;
			FSPartnerType _SubId = SubId;
			FSApptTypeType _ApptType = ApptType;
			FSApptStatType _ApptStat = ApptStat;
			GenericFloatType _MinHours = MinHours;
			GenericFloatType _MaxHours = MaxHours;
			ListYesNoType _Method = Method;
			LongDescType _NoteDesc = NoteDesc;
			LongDescType _NoteContent = NoteContent;
			StringType _ScheduleID = ScheduleID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSMultiDayScheduleLoadSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubId", _SubId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptType", _ApptType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStat", _ApptStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinHours", _MinHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxHours", _MaxHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Method", _Method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleID", _ScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
