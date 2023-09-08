//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetAllNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetAllNotes
	{
		(int? ReturnCode, string RefNotes,
		string Infobar) SSSFSGetAllNotesSp(string RefType,
		string RefNum,
		int? RefLineSuf = null,
		int? RefRelease = null,
		int? RefSeq = null,
		string RefNotes = null,
		string Infobar = null);
	}
	
	public class SSSFSGetAllNotes : ISSSFSGetAllNotes
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetAllNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RefNotes,
		string Infobar) SSSFSGetAllNotesSp(string RefType,
		string RefNum,
		int? RefLineSuf = null,
		int? RefRelease = null,
		int? RefSeq = null,
		string RefNotes = null,
		string Infobar = null)
		{
			FSRefNumType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			FSRefSeqType _RefSeq = RefSeq;
			StringType _RefNotes = RefNotes;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetAllNotesSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNotes", _RefNotes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefNotes = _RefNotes;
				Infobar = _Infobar;
				
				return (Severity, RefNotes, Infobar);
			}
		}
	}
}
