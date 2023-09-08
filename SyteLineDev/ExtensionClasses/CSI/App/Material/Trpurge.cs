//PROJECT NAME: Material
//CLASS NAME: Trpurge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITrpurge
	{
		(int? ReturnCode, string Infobar) TrpurgeSp(string SiteGroup,
		string BegTrnNum,
		string EndTrnNum,
		string BegFromWhse,
		string EndFromWhse,
		string BegToWhse,
		string EndToWhse,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		short? OrderStartingOffset = null,
		short? OrderEndingOffset = null,
		string Infobar = null);
	}
	
	public class Trpurge : ITrpurge
	{
		readonly IApplicationDB appDB;
		
		public Trpurge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TrpurgeSp(string SiteGroup,
		string BegTrnNum,
		string EndTrnNum,
		string BegFromWhse,
		string EndFromWhse,
		string BegToWhse,
		string EndToWhse,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		short? OrderStartingOffset = null,
		short? OrderEndingOffset = null,
		string Infobar = null)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			TrnNumType _BegTrnNum = BegTrnNum;
			TrnNumType _EndTrnNum = EndTrnNum;
			WhseType _BegFromWhse = BegFromWhse;
			WhseType _EndFromWhse = EndFromWhse;
			WhseType _BegToWhse = BegToWhse;
			WhseType _EndToWhse = EndToWhse;
			DateTimeType _OrderDateStarting = OrderDateStarting;
			DateTimeType _OrderDateEnding = OrderDateEnding;
			DateOffsetType _OrderStartingOffset = OrderStartingOffset;
			DateOffsetType _OrderEndingOffset = OrderEndingOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrpurgeSp";
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTrnNum", _BegTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnNum", _EndTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegFromWhse", _BegFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndFromWhse", _EndFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegToWhse", _BegToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndToWhse", _EndToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStartingOffset", _OrderStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEndingOffset", _OrderEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
