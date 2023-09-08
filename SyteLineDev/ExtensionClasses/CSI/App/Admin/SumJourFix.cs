//PROJECT NAME: Admin
//CLASS NAME: SumJourFix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class SumJourFix : ISumJourFix
	{
		IApplicationDB appDB;
		
		
		public SumJourFix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SumJourFixSp(string Id,
		DateTime? PSDate = null,
		DateTime? PEDate = null,
		string Infobar = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null)
		{
			JournalIdType _Id = Id;
			CurrentDateType _PSDate = PSDate;
			CurrentDateType _PEDate = PEDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumJourFixSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSDate", _PSDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEDate", _PEDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
