//PROJECT NAME: Production
//CLASS NAME: WBSCheckProjWbsValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSCheckProjWbsValid : IWBSCheckProjWbsValid
	{
		readonly IApplicationDB appDB;
		
		
		public WBSCheckProjWbsValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ValidRefNum,
		string ValidProjType) WBSCheckProjWbsValidSP(string RefType,
		string RefNum,
		string ValidRefNum,
		string ValidProjType)
		{
			LongListType _RefType = RefType;
			ProjWbsNumType _RefNum = RefNum;
			ProjWbsNumType _ValidRefNum = ValidRefNum;
			ProjProjTypeType _ValidProjType = ValidProjType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBSCheckProjWbsValidSP";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ValidRefNum", _ValidRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidProjType", _ValidProjType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ValidRefNum = _ValidRefNum;
				ValidProjType = _ValidProjType;
				
				return (Severity, ValidRefNum, ValidProjType);
			}
		}
	}
}
