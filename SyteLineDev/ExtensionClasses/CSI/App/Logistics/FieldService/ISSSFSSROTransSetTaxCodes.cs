//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransSetTaxCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROTransSetTaxCodes
	{
		(int? ReturnCode,
			string TaxCode1,
			string TaxCode2,
			int? PromptFor1,
			int? PromptFor2,
			string Infobar) SSSFSSROTransSetTaxCodesSp(
			string Table,
			string SroNum,
			string Item,
			string TaxCode1,
			string TaxCode2,
			int? PromptFor1,
			int? PromptFor2,
			string Infobar);
	}
}

