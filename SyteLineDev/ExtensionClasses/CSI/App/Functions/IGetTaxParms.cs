//PROJECT NAME: Data
//CLASS NAME: IGetTaxParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTaxParms
	{
		(int? ReturnCode,
			int? Tax_Enabled,
			string Tax_DefTaxCode,
			string Tax_TaxCodeLabel,
			string Tax_TaxIdLabel,
			int? Tax_PromptOnLine,
			string Tax_TaxMode,
			string Tax_TaxAmtLabel,
			string Tax_TaxAmtAccumLabel,
			string Tax_TaxItemLabel,
			int? Tax_ActiveForPurch,
			string Tax_TaxIdPromptLoc,
			string Tax_DefItemTaxCode,
			string Tax_DefMiscTaxCode,
			string Tax_DefFrtTaxCode,
			string Tax_TaxCodeDescLabel,
			string Tax_TaxItemDescLabel,
			string Tax_FrtCodeLabel,
			string Tax_FrtCodeDescLabel,
			string Tax_MiscCodeLabel,
			string Tax_MiscCodeDescLabel,
			string Infobar) GetTaxParmsSp(
			int? TaxSystem,
			int? Tax_Enabled,
			string Tax_DefTaxCode,
			string Tax_TaxCodeLabel,
			string Tax_TaxIdLabel,
			int? Tax_PromptOnLine,
			string Tax_TaxMode,
			string Tax_TaxAmtLabel,
			string Tax_TaxAmtAccumLabel,
			string Tax_TaxItemLabel,
			int? Tax_ActiveForPurch,
			string Tax_TaxIdPromptLoc,
			string Tax_DefItemTaxCode,
			string Tax_DefMiscTaxCode,
			string Tax_DefFrtTaxCode,
			string Tax_TaxCodeDescLabel,
			string Tax_TaxItemDescLabel,
			string Tax_FrtCodeLabel,
			string Tax_FrtCodeDescLabel,
			string Tax_MiscCodeLabel,
			string Tax_MiscCodeDescLabel,
			string Infobar);
	}
}

