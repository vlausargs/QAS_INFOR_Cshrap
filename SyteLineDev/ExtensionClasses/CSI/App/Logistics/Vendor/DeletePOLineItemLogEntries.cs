//PROJECT NAME: CSIVendor
//CLASS NAME: DeletePOLineItemLogEntries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDeletePOLineItemLogEntries
	{
		(int? ReturnCode, string Infobar) DeletePOLineItemLogEntriesSp(DateTime? SActivityDate = null,
		DateTime? EActivityDate = null,
		string SPoNum = null,
		string EPoNum = null,
		short? SPoLine = null,
		short? EPoLine = null,
		short? SPoRelease = null,
		short? EPoRelease = null,
		short? CreateInitial = 0,
		string Infobar = null,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null);
	}
	
	public class DeletePOLineItemLogEntries : IDeletePOLineItemLogEntries
	{
		readonly IApplicationDB appDB;
		
		public DeletePOLineItemLogEntries(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeletePOLineItemLogEntriesSp(DateTime? SActivityDate = null,
		DateTime? EActivityDate = null,
		string SPoNum = null,
		string EPoNum = null,
		short? SPoLine = null,
		short? EPoLine = null,
		short? SPoRelease = null,
		short? EPoRelease = null,
		short? CreateInitial = 0,
		string Infobar = null,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null)
		{
			DateType _SActivityDate = SActivityDate;
			DateType _EActivityDate = EActivityDate;
			PoNumType _SPoNum = SPoNum;
			PoNumType _EPoNum = EPoNum;
			PoLineType _SPoLine = SPoLine;
			PoLineType _EPoLine = EPoLine;
			PoReleaseType _SPoRelease = SPoRelease;
			PoReleaseType _EPoRelease = EPoRelease;
			SmallintType _CreateInitial = CreateInitial;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingActivityDateOffset = StartingActivityDateOffset;
			DateOffsetType _EndingActivityDateOffset = EndingActivityDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeletePOLineItemLogEntriesSp";
				
				appDB.AddCommandParameter(cmd, "SActivityDate", _SActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EActivityDate", _EActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoNum", _SPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoNum", _EPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoLine", _SPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoLine", _EPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoRelease", _SPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoRelease", _EPoRelease, ParameterDirection.Input);
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
