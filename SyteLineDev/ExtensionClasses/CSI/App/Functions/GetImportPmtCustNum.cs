//PROJECT NAME: Data
//CLASS NAME: GetImportPmtCustNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetImportPmtCustNum : IGetImportPmtCustNum
	{
		readonly IApplicationDB appDB;
		
		public GetImportPmtCustNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustNum,
			string Infobar) GetImportPmtCustNumSp(
			decimal? BatchId,
			int? HeaderNum,
			string RoutingNum,
			string AccountNum,
			string CustNum,
			string Infobar)
		{
			ARImportBatchIdType _BatchId = BatchId;
			ARImportHeaderNumType _HeaderNum = HeaderNum;
			BankTransitNumType _RoutingNum = RoutingNum;
			BankAccountType _AccountNum = AccountNum;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetImportPmtCustNumSp";
				
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HeaderNum", _HeaderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoutingNum", _RoutingNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountNum", _AccountNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				Infobar = _Infobar;
				
				return (Severity, CustNum, Infobar);
			}
		}
	}
}
