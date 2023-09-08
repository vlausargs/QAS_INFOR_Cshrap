//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcctChkUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcctChkUnit : ISSSFSAcctChkUnit
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAcctChkUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4) SSSFSAcctChkUnitSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4)
		{
			AcctType _oAcct = oAcct;
			UnitCode1Type _oUnit1 = oUnit1;
			UnitCode2Type _oUnit2 = oUnit2;
			UnitCode3Type _oUnit3 = oUnit3;
			UnitCode4Type _oUnit4 = oUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAcctChkUnitSp";
				
				appDB.AddCommandParameter(cmd, "oAcct", _oAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit1", _oUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit2", _oUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit3", _oUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit4", _oUnit4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oAcct = _oAcct;
				oUnit1 = _oUnit1;
				oUnit2 = _oUnit2;
				oUnit3 = _oUnit3;
				oUnit4 = _oUnit4;
				
				return (Severity, oAcct, oUnit1, oUnit2, oUnit3, oUnit4);
			}
		}
	}
}
