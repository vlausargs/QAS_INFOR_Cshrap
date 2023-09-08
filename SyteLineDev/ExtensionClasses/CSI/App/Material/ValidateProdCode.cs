//PROJECT NAME: Material
//CLASS NAME: ValidateProdCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateProdCode
	{
		(int? ReturnCode, string ProductCode, short? TaxFreeDays, string Infobar) ValidateProdCodeSp(string ProductCode,
		string Whse,
		short? TaxFreeDays,
		string Infobar,
		string PSite = null);
	}
	
	public class ValidateProdCode : IValidateProdCode
	{
		readonly IApplicationDB appDB;
		
		public ValidateProdCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ProductCode, short? TaxFreeDays, string Infobar) ValidateProdCodeSp(string ProductCode,
		string Whse,
		short? TaxFreeDays,
		string Infobar,
		string PSite = null)
		{
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			TaxFreeDaysType _TaxFreeDays = TaxFreeDays;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateProdCodeSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeDays", _TaxFreeDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProductCode = _ProductCode;
				TaxFreeDays = _TaxFreeDays;
				Infobar = _Infobar;
				
				return (Severity, ProductCode, TaxFreeDays, Infobar);
			}
		}
	}
}
