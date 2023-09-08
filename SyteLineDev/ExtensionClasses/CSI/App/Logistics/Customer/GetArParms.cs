//PROJECT NAME: Logistics
//CLASS NAME: GetArParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetArParms : IGetArParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetArParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		string Infobar,
		string Description) GetArParmsSp(string AcctType,
		string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		string Infobar,
		string Description = null)
		{
			LongListType _AcctType = AcctType;
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			UnitCode2Type _UnitCode2 = UnitCode2;
			UnitCode1Type _UnitCode3 = UnitCode3;
			UnitCode1Type _UnitCode4 = UnitCode4;
			InfobarType _Infobar = Infobar;
			DescriptionType _Description = Description;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetArParmsSp";
				
				appDB.AddCommandParameter(cmd, "AcctType", _AcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode3", _UnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode4", _UnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				UnitCode1 = _UnitCode1;
				UnitCode2 = _UnitCode2;
				UnitCode3 = _UnitCode3;
				UnitCode4 = _UnitCode4;
				Infobar = _Infobar;
				Description = _Description;
				
				return (Severity, Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, Infobar, Description);
			}
		}
	}
}
