//PROJECT NAME: Material
//CLASS NAME: IDistAcctExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IDistAcctExists
	{
		(int? ReturnCode, string Infobar) DistAcctExistsSp(string Whse,
		string ProductCode,
		string Infobar,
		string PSite = null);
	}
}

