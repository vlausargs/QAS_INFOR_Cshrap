//PROJECT NAME: Logistics
//CLASS NAME: GetPoChangeInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetPoChangeInfo : IGetPoChangeInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetPoChangeInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ChgNum,
		DateTime? ChgDate,
		string Stat,
		decimal? UserId) GetPoChangeInfoSp(string PoNum,
		int? ChgNum,
		DateTime? ChgDate,
		string Stat,
		decimal? UserId)
		{
			PoNumType _PoNum = PoNum;
			ChgNumType _ChgNum = ChgNum;
			DateType _ChgDate = ChgDate;
			PoChangeStatusType _Stat = Stat;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPoChangeInfoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChgNum", _ChgNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ChgDate", _ChgDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ChgNum = _ChgNum;
				ChgDate = _ChgDate;
				Stat = _Stat;
				UserId = _UserId;
				
				return (Severity, ChgNum, ChgDate, Stat, UserId);
			}
		}
	}
}
