//PROJECT NAME: Material
//CLASS NAME: ValidateProductCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ValidateProductCode : IValidateProductCode
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateProductCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ProductCode,
		string Infobar) ValidateProductCodeSp(string ProductCode,
		string Whse,
		string Infobar,
		string PSite = null)
		{
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateProductCodeSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProductCode = _ProductCode;
				Infobar = _Infobar;
				
				return (Severity, ProductCode, Infobar);
			}
		}
	}
}
