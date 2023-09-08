//PROJECT NAME: Data
//CLASS NAME: IPKMaint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPKMaint
	{
		int? PKMaintSp(
			int? Drop = 1,
			int? Create = 1,
			string Table = null);
	}
}

