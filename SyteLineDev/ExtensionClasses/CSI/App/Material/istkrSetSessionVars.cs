//PROJECT NAME: Material
//CLASS NAME: istkrSetSessionVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrSetSessionVars
	{
		int? istkrSetSessionVarsSp(string PUM,
		DateTime? PTrnDate,
		string PTrnReasonCode,
		string PTrnInvAdjAcct,
		string PTrnInvAdjAcctUnit1,
		string PTrnInvAdjAcctUnit2,
		string PTrnInvAdjAcctUnit3,
		string PTrnInvAdjAcctUnit4);
	}
	
	public class istkrSetSessionVars : IistkrSetSessionVars
	{
		readonly IApplicationDB appDB;
		
		public istkrSetSessionVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? istkrSetSessionVarsSp(string PUM,
		DateTime? PTrnDate,
		string PTrnReasonCode,
		string PTrnInvAdjAcct,
		string PTrnInvAdjAcctUnit1,
		string PTrnInvAdjAcctUnit2,
		string PTrnInvAdjAcctUnit3,
		string PTrnInvAdjAcctUnit4)
		{
			UMType _PUM = PUM;
			DateType _PTrnDate = PTrnDate;
			ReasonCodeType _PTrnReasonCode = PTrnReasonCode;
			AcctType _PTrnInvAdjAcct = PTrnInvAdjAcct;
			UnitCode1Type _PTrnInvAdjAcctUnit1 = PTrnInvAdjAcctUnit1;
			UnitCode2Type _PTrnInvAdjAcctUnit2 = PTrnInvAdjAcctUnit2;
			UnitCode3Type _PTrnInvAdjAcctUnit3 = PTrnInvAdjAcctUnit3;
			UnitCode4Type _PTrnInvAdjAcctUnit4 = PTrnInvAdjAcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrSetSessionVarsSp";
				
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnDate", _PTrnDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnReasonCode", _PTrnReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnInvAdjAcct", _PTrnInvAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnInvAdjAcctUnit1", _PTrnInvAdjAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnInvAdjAcctUnit2", _PTrnInvAdjAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnInvAdjAcctUnit3", _PTrnInvAdjAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnInvAdjAcctUnit4", _PTrnInvAdjAcctUnit4, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
