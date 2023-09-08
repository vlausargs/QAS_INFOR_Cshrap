//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchPartnerSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedDispatchPartnerSave : ISSSFSSchedDispatchPartnerSave
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSchedDispatchPartnerSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSchedDispatchPartnerSaveSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string PartnerId,
		DateTime? SchedDate,
		string ApptType,
		string ApptStat,
		string ApptDesc,
		decimal? ApptHrs,
		string NotesContent,
		string Infobar)
		{
			FSRefTypeJKNSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			FSRefSeqType _RefSeq = RefSeq;
			FSPartnerType _PartnerId = PartnerId;
			DateType _SchedDate = SchedDate;
			FSApptTypeType _ApptType = ApptType;
			FSApptStatType _ApptStat = ApptStat;
			DescriptionType _ApptDesc = ApptDesc;
			HoursOffType _ApptHrs = ApptHrs;
			StringType _NotesContent = NotesContent;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedDispatchPartnerSaveSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptType", _ApptType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStat", _ApptStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptDesc", _ApptDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptHrs", _ApptHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotesContent", _NotesContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
