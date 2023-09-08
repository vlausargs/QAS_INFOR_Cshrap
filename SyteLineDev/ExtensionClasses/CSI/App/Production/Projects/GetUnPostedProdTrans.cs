//PROJECT NAME: Production
//CLASS NAME: GetUnPostedProdTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetUnPostedProdTrans : IGetUnPostedProdTrans
	{
		readonly IApplicationDB appDB;
		
		
		public GetUnPostedProdTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? UnpostedDCSFC,
		int? UnpostedDCJM,
		int? UnpostedDCJMRcpt,
		int? UnpostedJobLaborTrans,
		int? UnpostedDCJIT,
		int? UnpostedDCPS,
		int? UnpostedDCPSScrap,
		int? UnpostedJobMatlTrans,
		int? UnpostedDCSFCWCLabor,
		int? UnpostedDCSFCWCMachine,
		int? UnpostedDCWC) GetUnPostedProdTransSp(int? UnpostedDCSFC,
		int? UnpostedDCJM,
		int? UnpostedDCJMRcpt,
		int? UnpostedJobLaborTrans,
		int? UnpostedDCJIT,
		int? UnpostedDCPS,
		int? UnpostedDCPSScrap,
		int? UnpostedJobMatlTrans,
		int? UnpostedDCSFCWCLabor,
		int? UnpostedDCSFCWCMachine,
		int? UnpostedDCWC)
		{
			IntType _UnpostedDCSFC = UnpostedDCSFC;
			IntType _UnpostedDCJM = UnpostedDCJM;
			IntType _UnpostedDCJMRcpt = UnpostedDCJMRcpt;
			IntType _UnpostedJobLaborTrans = UnpostedJobLaborTrans;
			IntType _UnpostedDCJIT = UnpostedDCJIT;
			IntType _UnpostedDCPS = UnpostedDCPS;
			IntType _UnpostedDCPSScrap = UnpostedDCPSScrap;
			IntType _UnpostedJobMatlTrans = UnpostedJobMatlTrans;
			IntType _UnpostedDCSFCWCLabor = UnpostedDCSFCWCLabor;
			IntType _UnpostedDCSFCWCMachine = UnpostedDCSFCWCMachine;
			IntType _UnpostedDCWC = UnpostedDCWC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUnPostedProdTransSp";
				
				appDB.AddCommandParameter(cmd, "UnpostedDCSFC", _UnpostedDCSFC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJM", _UnpostedDCJM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJMRcpt", _UnpostedDCJMRcpt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedJobLaborTrans", _UnpostedJobLaborTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJIT", _UnpostedDCJIT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCPS", _UnpostedDCPS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCPSScrap", _UnpostedDCPSScrap, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedJobMatlTrans", _UnpostedJobMatlTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCSFCWCLabor", _UnpostedDCSFCWCLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCSFCWCMachine", _UnpostedDCSFCWCMachine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCWC", _UnpostedDCWC, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnpostedDCSFC = _UnpostedDCSFC;
				UnpostedDCJM = _UnpostedDCJM;
				UnpostedDCJMRcpt = _UnpostedDCJMRcpt;
				UnpostedJobLaborTrans = _UnpostedJobLaborTrans;
				UnpostedDCJIT = _UnpostedDCJIT;
				UnpostedDCPS = _UnpostedDCPS;
				UnpostedDCPSScrap = _UnpostedDCPSScrap;
				UnpostedJobMatlTrans = _UnpostedJobMatlTrans;
				UnpostedDCSFCWCLabor = _UnpostedDCSFCWCLabor;
				UnpostedDCSFCWCMachine = _UnpostedDCSFCWCMachine;
				UnpostedDCWC = _UnpostedDCWC;
				
				return (Severity, UnpostedDCSFC, UnpostedDCJM, UnpostedDCJMRcpt, UnpostedJobLaborTrans, UnpostedDCJIT, UnpostedDCPS, UnpostedDCPSScrap, UnpostedJobMatlTrans, UnpostedDCSFCWCLabor, UnpostedDCSFCWCMachine, UnpostedDCWC);
			}
		}
	}
}
