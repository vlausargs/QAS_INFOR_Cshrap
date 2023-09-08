//PROJECT NAME: Data
//CLASS NAME: IEdiOutPlnpoP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPlnpoP
	{
		int? EdiOutPlnpoPSp(
			decimal? ProcessId);
	}
}

