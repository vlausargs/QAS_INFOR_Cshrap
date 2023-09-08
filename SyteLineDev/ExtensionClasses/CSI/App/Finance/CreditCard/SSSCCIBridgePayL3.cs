//PROJECT NAME: Finance
//CLASS NAME: SSSCCIBridgePayL3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIBridgePayL3 : ISSSCCIBridgePayL3
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIBridgePayL3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustPo,
			string Level3) SSSCCIBridgePayL3Sp(
			string InvNum,
			string CustPo,
			string Level3)
		{
			InvNumType _InvNum = InvNum;
			CustPoType _CustPo = CustPo;
			GenericCodeType _Level3 = Level3;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIBridgePayL3Sp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Level3", _Level3, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustPo = _CustPo;
				Level3 = _Level3;
				
				return (Severity, CustPo, Level3);
			}
		}
	}
}
