//PROJECT NAME: Data
//CLASS NAME: ITransNat2AllUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransNat2AllUsed
	{
		(int? ReturnCode,
			string Infobar) TransNat2AllUsedSp(
			string SiteRef,
			string TransNat2,
			string Infobar);
	}
}

