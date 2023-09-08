//PROJECT NAME: Codes
//CLASS NAME: IVerifyStkLocAccts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IVerifyStkLocAccts
	{
		(int? ReturnCode, string Infobar) VerifyStkLocAcctsSp(string Infobar);
	}
}

