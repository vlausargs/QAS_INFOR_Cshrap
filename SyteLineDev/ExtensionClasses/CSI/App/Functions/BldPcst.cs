//PROJECT NAME: Data
//CLASS NAME: BldPcst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BldPcst : IBldPcst
	{
		readonly IApplicationDB appDB;
		
		public BldPcst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BldPcstSp(
			string CostNum,
			string RefType,
			string RefNum,
			int? RefLine,
			int? DeleteOld,
			string CostCodeType)
		{
			ProjWbsNumType _CostNum = CostNum;
			ProjTypeType _RefType = RefType;
			ProjWbsNumType _RefNum = RefNum;
			TaskNumType _RefLine = RefLine;
			ListYesNoType _DeleteOld = DeleteOld;
			CostCodeTypeType _CostCodeType = CostCodeType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BldPcstSp";
				
				appDB.AddCommandParameter(cmd, "CostNum", _CostNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteOld", _DeleteOld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
