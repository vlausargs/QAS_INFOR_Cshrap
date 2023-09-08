//PROJECT NAME: Codes
//CLASS NAME: IProductCodeDistAcctExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IProductCodeDistAcctExists
	{
		(int? ReturnCode, string Infobar) ProductCodeDistAcctExistsSp(string ProductCode,
		string Infobar);
	}
}

