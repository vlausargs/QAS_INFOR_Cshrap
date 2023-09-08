//PROJECT NAME: CSIProduct
//CLASS NAME: DelEopCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IDelEopCost
	{
		(int? ReturnCode, string Infobar) DelEopCostSp(string StartingWc,
		string EndingWc,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DelEopCost : IDelEopCost
	{
		readonly IApplicationDB appDB;
		
		public DelEopCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DelEopCostSp(string StartingWc,
		string EndingWc,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			WcType _StartingWc = StartingWc;
			WcType _EndingWc = EndingWc;
			DateType _StartingDate = StartingDate;
			DateType _EndingDate = EndingDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelEopCostSp";
				
				appDB.AddCommandParameter(cmd, "StartingWc", _StartingWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWc", _EndingWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
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
