//PROJECT NAME: Data
//CLASS NAME: IEdiOutPoP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPoP
	{
		int? EdiOutPoPSp(
			decimal? ProcessId);
	}
}

