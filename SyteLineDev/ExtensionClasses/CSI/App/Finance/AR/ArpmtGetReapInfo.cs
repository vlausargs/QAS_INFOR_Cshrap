//PROJECT NAME: Finance
//CLASS NAME: ArpmtGetReapInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtGetReapInfo : IArpmtGetReapInfo
	{
		readonly IApplicationDB appDB;
		
		public ArpmtGetReapInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PInvDate) ArpmtGetReapInfoSp(
			string PCustNum,
			int? PCheckNum,
			string PPayType,
			DateTime? PInvDate)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			CustPayTypeType _PPayType = PPayType;
			DateType _PInvDate = PInvDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtGetReapInfoSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PInvDate = _PInvDate;
				
				return (Severity, PInvDate);
			}
		}
	}
}
