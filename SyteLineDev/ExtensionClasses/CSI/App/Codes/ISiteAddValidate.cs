//PROJECT NAME: Codes
//CLASS NAME: ISiteAddValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteAddValidate
	{
		(int? ReturnCode, string Infobar) SiteAddValidateSp(string PSite,
		string Infobar);
	}
}

