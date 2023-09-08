//PROJECT NAME: Data
//CLASS NAME: ITransNatAllUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransNatAllUsed
	{
		(int? ReturnCode,
			string Infobar) TransNatAllUsedSp(
			string SiteRef,
			string TransNat,
			string Infobar);
	}
}

