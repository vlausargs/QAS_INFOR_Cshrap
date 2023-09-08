//PROJECT NAME: Codes
//CLASS NAME: GetCurrDecimalPlaces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetCurrDecimalPlaces : IGetCurrDecimalPlaces
	{
		readonly IApplicationDB appDB;
		
		
		public GetCurrDecimalPlaces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DecimalPlaces,
		string Infobar) GetCurrDecimalPlacesSp(string CurrCode,
		int? DecimalPlaces,
		string Infobar)
		{
			CurrCodeType _CurrCode = CurrCode;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurrDecimalPlacesSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DecimalPlaces = _DecimalPlaces;
				Infobar = _Infobar;
				
				return (Severity, DecimalPlaces, Infobar);
			}
		}
	}
}
