//PROJECT NAME: Material
//CLASS NAME: MrpProcessReqRecords.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpProcessReqRecords : IMrpProcessReqRecords
	{
		readonly IApplicationDB appDB;
		
		public MrpProcessReqRecords(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? RecordCnt,
			string Infobar) MrpProcessReqRecordsSp(
			string PlannerCode,
			string Buyer,
			string Source,
			string Whse,
			decimal? UserId,
			int? RecordCnt,
			string Infobar)
		{
			UserCodeType _PlannerCode = PlannerCode;
			UsernameType _Buyer = Buyer;
			StringType _Source = Source;
			WhseType _Whse = Whse;
			TokenType _UserId = UserId;
			IntType _RecordCnt = RecordCnt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpProcessReqRecordsSp";
				
				appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCnt", _RecordCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RecordCnt = _RecordCnt;
				Infobar = _Infobar;
				
				return (Severity, RecordCnt, Infobar);
			}
		}
	}
}
