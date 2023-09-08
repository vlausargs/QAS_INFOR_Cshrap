//PROJECT NAME: Data
//CLASS NAME: CommCalcCon.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CommCalcCon : ICommCalcCon
	{
		readonly IApplicationDB appDB;
		
		public CommCalcCon(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CommCalcConSp(
			string InvHdrInvNum,
			string TContract,
			string InvCred,
			string Infobar)
		{
			InvNumType _InvHdrInvNum = InvHdrInvNum;
			FSContractType _TContract = TContract;
			StringType _InvCred = InvCred;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CommCalcConSp";
				
				appDB.AddCommandParameter(cmd, "InvHdrInvNum", _InvHdrInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TContract", _TContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
