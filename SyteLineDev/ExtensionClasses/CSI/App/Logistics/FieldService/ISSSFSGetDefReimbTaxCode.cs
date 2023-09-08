//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetDefReimbTaxCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetDefReimbTaxCode
	{
		(int? ReturnCode,
			string ReimbTaxCode1,
			string ReimbTaxCode2,
			string Infobar) SSSFSGetDefReimbTaxCodeSp(
			string PartnerId,
			string ReimbTaxCode1,
			string ReimbTaxCode2,
			string Infobar);
	}
}

