//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProdacct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSProdacct : ISSSFSProdacct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSProdacct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Acct,
			string UnitCode1,
			string UnitCode2,
			string UnitCode3,
			string UnitCode4,
			string Infobar) SSSFSProdacctSp(
			string ProductCode,
			string Prefix,
			string Acct,
			string UnitCode1,
			string UnitCode2,
			string UnitCode3,
			string UnitCode4,
			string Infobar)
		{
			ProductCodeType _ProductCode = ProductCode;
			StringType _Prefix = Prefix;
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			UnitCode2Type _UnitCode2 = UnitCode2;
			UnitCode3Type _UnitCode3 = UnitCode3;
			UnitCode4Type _UnitCode4 = UnitCode4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSProdacctSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode3", _UnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode4", _UnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				UnitCode1 = _UnitCode1;
				UnitCode2 = _UnitCode2;
				UnitCode3 = _UnitCode3;
				UnitCode4 = _UnitCode4;
				Infobar = _Infobar;
				
				return (Severity, Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, Infobar);
			}
		}
	}
}
