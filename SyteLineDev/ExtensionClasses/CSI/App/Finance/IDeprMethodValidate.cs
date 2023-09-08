//PROJECT NAME: Finance
//CLASS NAME: IDeprMethodValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IDeprMethodValidate
	{
		(int? ReturnCode, string Method,
		string Infobar) DeprMethodValidateSp(string Method,
		string Infobar);
	}
}

