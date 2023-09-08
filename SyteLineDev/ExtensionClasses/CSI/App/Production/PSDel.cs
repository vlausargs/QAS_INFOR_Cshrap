//PROJECT NAME: Production
//CLASS NAME: PSDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSDel
	{
		(int? ReturnCode, int? CounterItem, string Infobar) PSDelSp(DateTime? ToDate = null,
		DateTime? FromDate = null,
		string ToPSNum = null,
		string FromPSNum = null,
		string ToPSItem = null,
		string FromPSItem = null,
		int? CounterItem = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class PSDel : IPSDel
	{
		readonly IApplicationDB appDB;
		
		public PSDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CounterItem, string Infobar) PSDelSp(DateTime? ToDate = null,
		DateTime? FromDate = null,
		string ToPSNum = null,
		string FromPSNum = null,
		string ToPSItem = null,
		string FromPSItem = null,
		int? CounterItem = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			DateType _ToDate = ToDate;
			DateType _FromDate = FromDate;
			PsNumType _ToPSNum = ToPSNum;
			PsNumType _FromPSNum = FromPSNum;
			ItemType _ToPSItem = ToPSItem;
			ItemType _FromPSItem = FromPSItem;
			IntType _CounterItem = CounterItem;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSDelSp";
				
				appDB.AddCommandParameter(cmd, "ToDate", _ToDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDate", _FromDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPSNum", _ToPSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPSNum", _FromPSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPSItem", _ToPSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPSItem", _FromPSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CounterItem = _CounterItem;
				Infobar = _Infobar;
				
				return (Severity, CounterItem, Infobar);
			}
		}
	}
}
