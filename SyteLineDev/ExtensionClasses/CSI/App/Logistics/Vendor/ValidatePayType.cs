//PROJECT NAME: Logistics
//CLASS NAME: ValidatePayType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePayType : IValidatePayType
	{
		readonly IApplicationDB appDB;
		
		
		public ValidatePayType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidatePayTypeSp(string EntityPayType,
		string EntityCurrCode,
		string EntityBankCode,
		string Infobar)
		{
			StringType _EntityPayType = EntityPayType;
			CurrCodeType _EntityCurrCode = EntityCurrCode;
			BankCodeType _EntityBankCode = EntityBankCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePayTypeSp";
				
				appDB.AddCommandParameter(cmd, "EntityPayType", _EntityPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntityCurrCode", _EntityCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntityBankCode", _EntityBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
