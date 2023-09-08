//PROJECT NAME: Logistics
//CLASS NAME: ValidateSalesTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateSalesTax : IValidateSalesTax
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateSalesTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateSalesTaxSp(int? PTaxSystem,
		string PTaxCode,
		decimal? PTaxBasis,
		string PVendNum,
		decimal? PSalesTax,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			TaxSystemType _PTaxSystem = PTaxSystem;
			TaxCodeType _PTaxCode = PTaxCode;
			AmountType _PTaxBasis = PTaxBasis;
			VendNumType _PVendNum = PVendNum;
			AmountType _PSalesTax = PSalesTax;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSalesTaxSp";
				
				appDB.AddCommandParameter(cmd, "PTaxSystem", _PTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode", _PTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxBasis", _PTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
