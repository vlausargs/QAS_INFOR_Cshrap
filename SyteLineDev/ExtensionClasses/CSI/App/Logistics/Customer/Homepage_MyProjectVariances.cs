//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyProjectVariances.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MyProjectVariances
	{
		(int? ReturnCode, int? InControl, int? SchedVarY, int? SchedVarR, int? CostVarY, int? CostVarR) Homepage_MyProjectVariancesSp(string ProjMgr = null,
		int? InControl = null,
		int? SchedVarY = null,
		int? SchedVarR = null,
		int? CostVarY = null,
		int? CostVarR = null);
	}
	
	public class Homepage_MyProjectVariances : IHomepage_MyProjectVariances
	{
		readonly IApplicationDB appDB;
		
		public Homepage_MyProjectVariances(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? InControl, int? SchedVarY, int? SchedVarR, int? CostVarY, int? CostVarR) Homepage_MyProjectVariancesSp(string ProjMgr = null,
		int? InControl = null,
		int? SchedVarY = null,
		int? SchedVarR = null,
		int? CostVarY = null,
		int? CostVarR = null)
		{
			NameType _ProjMgr = ProjMgr;
			IntType _InControl = InControl;
			IntType _SchedVarY = SchedVarY;
			IntType _SchedVarR = SchedVarR;
			IntType _CostVarY = CostVarY;
			IntType _CostVarR = CostVarR;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_MyProjectVariancesSp";
				
				appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InControl", _InControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedVarY", _SchedVarY, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedVarR", _SchedVarR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostVarY", _CostVarY, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostVarR", _CostVarR, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InControl = _InControl;
				SchedVarY = _SchedVarY;
				SchedVarR = _SchedVarR;
				CostVarY = _CostVarY;
				CostVarR = _CostVarR;
				
				return (Severity, InControl, SchedVarY, SchedVarR, CostVarY, CostVarR);
			}
		}
	}
}
