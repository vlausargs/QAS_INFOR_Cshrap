//PROJECT NAME: Finance
//CLASS NAME: IVendCustEmpNameFromRefType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVendCustEmpNameFromRefType
	{
		(int? ReturnCode, string Name,
		string Infobar) VendCustEmpNameFromRefTypeSp(string RefNum,
		string RefType,
		string Name,
		string Infobar);

		string VendCustEmpNameFromRefTypeFn(
			string RefNum,
			string RefType);
	}
}

