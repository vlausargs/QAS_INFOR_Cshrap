//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCreateInvRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCreateInvRef : ISSSFSConInvSubCreateInvRef
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCreateInvRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubCreateInvRefSp(
			string Contract,
			string InvNum)
		{
			FSContractType _Contract = Contract;
			InvNumType _InvNum = InvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCreateInvRefSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
