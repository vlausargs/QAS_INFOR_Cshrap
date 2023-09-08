//PROJECT NAME: Finance
//CLASS NAME: CheckDraftNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Drafts
{
	public class CheckDraftNum : ICheckDraftNum
	{
		readonly IApplicationDB appDB;
		
		public CheckDraftNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckDraftNumSp(
			string CustNum,
			string InvNum,
			string Infobar)
		{
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckDraftNumSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
