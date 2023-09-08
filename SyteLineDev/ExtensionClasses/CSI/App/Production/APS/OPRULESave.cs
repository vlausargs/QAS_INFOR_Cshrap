//PROJECT NAME: Production
//CLASS NAME: OPRULESave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class OPRULESave : IOPRULESave
	{
		readonly IApplicationDB appDB;
		
		
		public OPRULESave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? OPRULESaveSp(int? InsertFlag,
		int? AltNo,
		int? RULESEQ,
		int? RULETYPE,
		string RULEVALUE,
		Guid? RowPointer)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsSmallIntType _RULESEQ = RULESEQ;
			ApsIntType _RULETYPE = RULETYPE;
			ApsRulevalType _RULEVALUE = RULEVALUE;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OPRULESaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RULESEQ", _RULESEQ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RULETYPE", _RULETYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RULEVALUE", _RULEVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
