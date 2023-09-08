//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXEncryptPasswordWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXEncryptPasswordWrap
	{
		(int? ReturnCode, string EncryptedPassword,
		string Infobar) SSSVTXEncryptPasswordWrapSp(string Password,
		string EncryptedPassword,
		string Infobar);
	}
}

