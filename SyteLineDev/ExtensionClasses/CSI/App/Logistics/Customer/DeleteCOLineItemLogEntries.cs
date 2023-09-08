//PROJECT NAME: CSICustomer
//CLASS NAME: DeleteCOLineItemLogEntries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDeleteCOLineItemLogEntries
	{
		(int? ReturnCode, string Infobar) DeleteCOLineItemLogEntriesSP(DateTime? SActivityDate,
		DateTime? EActivityDate,
		string SCoNum,
		string ECoNum,
		short? SCoLine,
		short? ECoLine,
		short? SCoRelease,
		short? ECoRelease,
		short? CreateInitial,
		string Infobar,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null);
	}
	
	public class DeleteCOLineItemLogEntries : IDeleteCOLineItemLogEntries
	{
		readonly IApplicationDB appDB;
		
		public DeleteCOLineItemLogEntries(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteCOLineItemLogEntriesSP(DateTime? SActivityDate,
		DateTime? EActivityDate,
		string SCoNum,
		string ECoNum,
		short? SCoLine,
		short? ECoLine,
		short? SCoRelease,
		short? ECoRelease,
		short? CreateInitial,
		string Infobar,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null)
		{
			DateType _SActivityDate = SActivityDate;
			DateType _EActivityDate = EActivityDate;
			CoNumType _SCoNum = SCoNum;
			CoNumType _ECoNum = ECoNum;
			CoLineType _SCoLine = SCoLine;
			CoLineType _ECoLine = ECoLine;
			CoReleaseType _SCoRelease = SCoRelease;
			CoReleaseType _ECoRelease = ECoRelease;
			SmallintType _CreateInitial = CreateInitial;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingActivityDateOffset = StartingActivityDateOffset;
			DateOffsetType _EndingActivityDateOffset = EndingActivityDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteCOLineItemLogEntriesSP";
				
				appDB.AddCommandParameter(cmd, "SActivityDate", _SActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EActivityDate", _EActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCoNum", _SCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECoNum", _ECoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCoLine", _SCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECoLine", _ECoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCoRelease", _SCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECoRelease", _ECoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateInitial", _CreateInitial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingActivityDateOffset", _StartingActivityDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingActivityDateOffset", _EndingActivityDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
