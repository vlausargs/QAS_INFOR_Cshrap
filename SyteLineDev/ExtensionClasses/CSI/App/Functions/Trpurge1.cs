//PROJECT NAME: Data
//CLASS NAME: Trpurge1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Trpurge1 : ITrpurge1
	{
		readonly IApplicationDB appDB;
		
		public Trpurge1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Counter,
			string Infobar) Trpurge1Sp(
			string BegTrnNum,
			string EndTrnNum,
			string BegFromWhse,
			string EndFromWhse,
			string BegToWhse,
			string EndToWhse,
			string Site,
			int? Counter,
			DateTime? OrderDateStarting,
			DateTime? OrderDateEnding,
			string Infobar)
		{
			TrnNumType _BegTrnNum = BegTrnNum;
			TrnNumType _EndTrnNum = EndTrnNum;
			WhseType _BegFromWhse = BegFromWhse;
			WhseType _EndFromWhse = EndFromWhse;
			WhseType _BegToWhse = BegToWhse;
			WhseType _EndToWhse = EndToWhse;
			SiteType _Site = Site;
			IntType _Counter = Counter;
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Trpurge1Sp";
				
				appDB.AddCommandParameter(cmd, "BegTrnNum", _BegTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnNum", _EndTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegFromWhse", _BegFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndFromWhse", _EndFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegToWhse", _BegToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndToWhse", _EndToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Counter = _Counter;
				Infobar = _Infobar;
				
				return (Severity, Counter, Infobar);
			}
		}
	}
}
