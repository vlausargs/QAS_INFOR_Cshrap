//PROJECT NAME: Finance
//CLASS NAME: Gljous.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class Gljous : IGljous
	{
		readonly IApplicationDB appDB;
		
		
		public Gljous(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GljousSp(string PId,
		int? PFromSeq,
		int? PToSeq,
		int? PFirstSeq,
		int? PStepSize,
		string PTitle,
		string Infobar)
		{
			JournalIdType _PId = PId;
			JournalSeqType _PFromSeq = PFromSeq;
			JournalSeqType _PToSeq = PToSeq;
			JournalSeqType _PFirstSeq = PFirstSeq;
			JournalSeqType _PStepSize = PStepSize;
			MiscTitleType _PTitle = PTitle;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GljousSp";
				
				appDB.AddCommandParameter(cmd, "PId", _PId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSeq", _PFromSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSeq", _PToSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFirstSeq", _PFirstSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStepSize", _PStepSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTitle", _PTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
