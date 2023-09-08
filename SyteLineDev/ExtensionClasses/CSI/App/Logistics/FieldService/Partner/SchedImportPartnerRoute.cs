//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedImportPartnerRoute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedImportPartnerRoute
	{
		int SchedImportPartnerRouteSp(Guid? SessionID,
		                              string ProfileUsername,
		                              string ScheduleID,
		                              int? Seq,
		                              string PartnerId,
		                              string Description,
		                              string RefType,
		                              string RefNum,
		                              int? RefLineSuf,
		                              int? RefRelease,
		                              int? RefSeq,
		                              Guid? RowPointer,
		                              ref string Infobar);
	}
	
	public class SchedImportPartnerRoute : ISchedImportPartnerRoute
	{
		readonly IApplicationDB appDB;
		
		public SchedImportPartnerRoute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SchedImportPartnerRouteSp(Guid? SessionID,
		                                     string ProfileUsername,
		                                     string ScheduleID,
		                                     int? Seq,
		                                     string PartnerId,
		                                     string Description,
		                                     string RefType,
		                                     string RefNum,
		                                     int? RefLineSuf,
		                                     int? RefRelease,
		                                     int? RefSeq,
		                                     Guid? RowPointer,
		                                     ref string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			StringType _ProfileUsername = ProfileUsername;
			StringType _ScheduleID = ScheduleID;
			FSSeqType _Seq = Seq;
			FSPartnerType _PartnerId = PartnerId;
			DescriptionType _Description = Description;
			FSRefTypeJKNSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			FSRefSeqType _RefSeq = RefSeq;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedImportPartnerRouteSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProfileUsername", _ProfileUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleID", _ScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
