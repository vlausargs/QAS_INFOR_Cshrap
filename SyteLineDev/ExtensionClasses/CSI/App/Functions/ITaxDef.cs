//PROJECT NAME: Data
//CLASS NAME: ITaxDef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxDef
	{
		(int? ReturnCode,
			string Infobar,
			int? PActiveForPurch1,
			int? PActiveForPurch2,
			int? PPromptOnline1,
			int? PPromptOnline2,
			string PPromptWhere1,
			string PPromptWhere2,
			string PDefTaxcode1,
			string PDefTaxcode2,
			string PDefFrtTaxcode1,
			string PDefFrtTaxcode2,
			string PDefMscTaxcode1,
			string PDefMscTaxcode2,
			string PItemTaxcode1,
			string PItemTaxcode2,
			string PMode1,
			string PMode2,
			string PTaxamtLabel_1,
			string PTaxamtLabel_2,
			string PTaxcodeLabel_1,
			string PTaxcodeLabel_2,
			string PTaxitemLabel_1,
			string PTaxitemLabel_2,
			string PTaxidLabel_1,
			string PTaxidLabel_2,
			string PTaxdesc_1,
			string PTaxdesc_2,
			string PFrtdesc_1,
			string PFrtdesc_2,
			string PMscdesc_1,
			string PMscdesc_2) TaxDefSp(
			int? PNoColon = 1,
			string Infobar = null,
			int? PActiveForPurch1 = 0,
			int? PActiveForPurch2 = 0,
			int? PPromptOnline1 = 0,
			int? PPromptOnline2 = 0,
			string PPromptWhere1 = "",
			string PPromptWhere2 = "",
			string PDefTaxcode1 = "",
			string PDefTaxcode2 = "",
			string PDefFrtTaxcode1 = "",
			string PDefFrtTaxcode2 = "",
			string PDefMscTaxcode1 = "",
			string PDefMscTaxcode2 = "",
			string PItemTaxcode1 = "",
			string PItemTaxcode2 = "",
			string PMode1 = "",
			string PMode2 = "",
			string PTaxamtLabel_1 = "",
			string PTaxamtLabel_2 = "",
			string PTaxcodeLabel_1 = "",
			string PTaxcodeLabel_2 = "",
			string PTaxitemLabel_1 = "",
			string PTaxitemLabel_2 = "",
			string PTaxidLabel_1 = "",
			string PTaxidLabel_2 = "",
			string PTaxdesc_1 = "",
			string PTaxdesc_2 = "",
			string PFrtdesc_1 = "",
			string PFrtdesc_2 = "",
			string PMscdesc_1 = "",
			string PMscdesc_2 = "");
	}
}

