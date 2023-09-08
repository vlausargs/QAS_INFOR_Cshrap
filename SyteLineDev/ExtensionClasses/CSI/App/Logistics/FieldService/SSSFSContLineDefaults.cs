//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSContLineDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContLineDefaults
	{
		int SSSFSContLineDefaultsSp(ref string ContractSurchargeAcct,
		                            ref string ContractSurchargeAcctUnit1,
		                            ref string ContractSurchargeAcctUnit2,
		                            ref string ContractSurchargeAcctUnit3,
		                            ref string ContractSurchargeAcctUnit4,
		                            ref string Infobar);
	}
	
	public class SSSFSContLineDefaults : ISSSFSContLineDefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContLineDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSContLineDefaultsSp(ref string ContractSurchargeAcct,
		                                   ref string ContractSurchargeAcctUnit1,
		                                   ref string ContractSurchargeAcctUnit2,
		                                   ref string ContractSurchargeAcctUnit3,
		                                   ref string ContractSurchargeAcctUnit4,
		                                   ref string Infobar)
		{
			AcctType _ContractSurchargeAcct = ContractSurchargeAcct;
			UnitCode1Type _ContractSurchargeAcctUnit1 = ContractSurchargeAcctUnit1;
			UnitCode2Type _ContractSurchargeAcctUnit2 = ContractSurchargeAcctUnit2;
			UnitCode3Type _ContractSurchargeAcctUnit3 = ContractSurchargeAcctUnit3;
			UnitCode4Type _ContractSurchargeAcctUnit4 = ContractSurchargeAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContLineDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "ContractSurchargeAcct", _ContractSurchargeAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractSurchargeAcctUnit1", _ContractSurchargeAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractSurchargeAcctUnit2", _ContractSurchargeAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractSurchargeAcctUnit3", _ContractSurchargeAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractSurchargeAcctUnit4", _ContractSurchargeAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ContractSurchargeAcct = _ContractSurchargeAcct;
				ContractSurchargeAcctUnit1 = _ContractSurchargeAcctUnit1;
				ContractSurchargeAcctUnit2 = _ContractSurchargeAcctUnit2;
				ContractSurchargeAcctUnit3 = _ContractSurchargeAcctUnit3;
				ContractSurchargeAcctUnit4 = _ContractSurchargeAcctUnit4;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
