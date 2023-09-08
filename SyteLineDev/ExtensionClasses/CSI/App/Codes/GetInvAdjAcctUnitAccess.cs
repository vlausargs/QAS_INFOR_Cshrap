//PROJECT NAME: CSICodes
//CLASS NAME: GetInvAdjAcctUnitAccess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetInvAdjAcctUnitAccess
	{
		int GetInvAdjAcctUnitAccessSp(string PReasonCode,
		                              string PReasonClass,
		                              string PProductCode,
		                              ref string PAcct,
		                              ref string PAcctUnit1,
		                              ref string PAcctUnit2,
		                              ref string PAcctUnit3,
		                              ref string PAcctUnit4,
		                              ref string Description,
		                              ref string PAccessUnit1,
		                              ref string PAccessUnit2,
		                              ref string PAccessUnit3,
		                              ref string PAccessUnit4);
	}
	
	public class GetInvAdjAcctUnitAccess : IGetInvAdjAcctUnitAccess
	{
		readonly IApplicationDB appDB;
		
		public GetInvAdjAcctUnitAccess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetInvAdjAcctUnitAccessSp(string PReasonCode,
		                                     string PReasonClass,
		                                     string PProductCode,
		                                     ref string PAcct,
		                                     ref string PAcctUnit1,
		                                     ref string PAcctUnit2,
		                                     ref string PAcctUnit3,
		                                     ref string PAcctUnit4,
		                                     ref string Description,
		                                     ref string PAccessUnit1,
		                                     ref string PAccessUnit2,
		                                     ref string PAccessUnit3,
		                                     ref string PAccessUnit4)
		{
			ReasonCodeType _PReasonCode = PReasonCode;
			ReasonClassType _PReasonClass = PReasonClass;
			ProductCodeType _PProductCode = PProductCode;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			DescriptionType _Description = Description;
			UnitCodeAccessType _PAccessUnit1 = PAccessUnit1;
			UnitCodeAccessType _PAccessUnit2 = PAccessUnit2;
			UnitCodeAccessType _PAccessUnit3 = PAccessUnit3;
			UnitCodeAccessType _PAccessUnit4 = PAccessUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInvAdjAcctUnitAccessSp";
				
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonClass", _PReasonClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProductCode", _PProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAccessUnit1", _PAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAccessUnit2", _PAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAccessUnit3", _PAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAccessUnit4", _PAccessUnit4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PAcctUnit1 = _PAcctUnit1;
				PAcctUnit2 = _PAcctUnit2;
				PAcctUnit3 = _PAcctUnit3;
				PAcctUnit4 = _PAcctUnit4;
				Description = _Description;
				PAccessUnit1 = _PAccessUnit1;
				PAccessUnit2 = _PAccessUnit2;
				PAccessUnit3 = _PAccessUnit3;
				PAccessUnit4 = _PAccessUnit4;
				
				return Severity;
			}
		}
	}
}
