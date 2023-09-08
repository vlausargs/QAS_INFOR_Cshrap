//PROJECT NAME: CSIVendor
//CLASS NAME: GetApParmsDraftsPayableAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetApParmsDraftsPayableAcct
	{
		int GetApParmsDraftsPayableAcctSp(ref string Acct,
		                                  ref string UnitCode1,
		                                  ref string UnitCode2,
		                                  ref string UnitCode3,
		                                  ref string UnitCode4);
	}
	
	public class GetApParmsDraftsPayableAcct : IGetApParmsDraftsPayableAcct
	{
		readonly IApplicationDB appDB;
		
		public GetApParmsDraftsPayableAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetApParmsDraftsPayableAcctSp(ref string Acct,
		                                         ref string UnitCode1,
		                                         ref string UnitCode2,
		                                         ref string UnitCode3,
		                                         ref string UnitCode4)
		{
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			UnitCode2Type _UnitCode2 = UnitCode2;
			UnitCode1Type _UnitCode3 = UnitCode3;
			UnitCode1Type _UnitCode4 = UnitCode4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApParmsDraftsPayableAcctSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode3", _UnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode4", _UnitCode4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				UnitCode1 = _UnitCode1;
				UnitCode2 = _UnitCode2;
				UnitCode3 = _UnitCode3;
				UnitCode4 = _UnitCode4;
				
				return Severity;
			}
		}
	}
}
