//PROJECT NAME: Logistics
//CLASS NAME: ValidatePayTypeAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePayTypeAll : IValidatePayTypeAll
	{
		readonly IApplicationDB appDB;
		
		
		public ValidatePayTypeAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidatePayTypeAllSp(string EntityPayType,
		string EntityCurrCode,
		string EntityBankCode,
		string Site,
		string Infobar)
		{
			StringType _EntityPayType = EntityPayType;
			CurrCodeType _EntityCurrCode = EntityCurrCode;
			BankCodeType _EntityBankCode = EntityBankCode;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePayTypeAllSp";
				
				appDB.AddCommandParameter(cmd, "EntityPayType", _EntityPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntityCurrCode", _EntityCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntityBankCode", _EntityBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
