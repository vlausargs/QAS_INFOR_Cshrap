//PROJECT NAME: Logistics
//CLASS NAME: GetARAgingInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetARAgingInfo : IGetARAgingInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetARAgingInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6) GetARAgingInfoSp(int? PSubordinate,
		string PCustNum,
		int? PSiteQuery,
		decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6)
		{
			FlagNyType _PSubordinate = PSubordinate;
			CustNumType _PCustNum = PCustNum;
			FlagNyType _PSiteQuery = PSiteQuery;
			GenericDecimalType _PAgeBal1 = PAgeBal1;
			GenericDecimalType _PAgeBal2 = PAgeBal2;
			GenericDecimalType _PAgeBal3 = PAgeBal3;
			GenericDecimalType _PAgeBal4 = PAgeBal4;
			GenericDecimalType _PAgeBal5 = PAgeBal5;
			GenericDecimalType _PAgeBal6 = PAgeBal6;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetARAgingInfoSp";
				
				appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteQuery", _PSiteQuery, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAgeBal1", _PAgeBal1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal2", _PAgeBal2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal3", _PAgeBal3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal4", _PAgeBal4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal5", _PAgeBal5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal6", _PAgeBal6, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAgeBal1 = _PAgeBal1;
				PAgeBal2 = _PAgeBal2;
				PAgeBal3 = _PAgeBal3;
				PAgeBal4 = _PAgeBal4;
				PAgeBal5 = _PAgeBal5;
				PAgeBal6 = _PAgeBal6;
				
				return (Severity, PAgeBal1, PAgeBal2, PAgeBal3, PAgeBal4, PAgeBal5, PAgeBal6);
			}
		}
	}
}
