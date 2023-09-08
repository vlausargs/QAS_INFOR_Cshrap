//PROJECT NAME: Codes
//CLASS NAME: UpdateEuroParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UpdateEuroParms : IUpdateEuroParms
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateEuroParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateEuroParmsSp(int? CurrParmsParmKey,
		string EuroParmsCurrCode,
		string Infobar)
		{
			ParmKeyType _CurrParmsParmKey = CurrParmsParmKey;
			CurrCodeType _EuroParmsCurrCode = EuroParmsCurrCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateEuroParmsSp";
				
				appDB.AddCommandParameter(cmd, "CurrParmsParmKey", _CurrParmsParmKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EuroParmsCurrCode", _EuroParmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
