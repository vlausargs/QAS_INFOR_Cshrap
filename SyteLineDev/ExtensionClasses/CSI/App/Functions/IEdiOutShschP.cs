//PROJECT NAME: Data
//CLASS NAME: IEdiOutShschP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutShschP
	{
		int? EdiOutShschPSp(
			decimal? ProcessId);
	}
}

