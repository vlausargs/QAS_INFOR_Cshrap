//PROJECT NAME: Data
//CLASS NAME: ICrtLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICrtLog
	{
		int? CrtLogSp(
			string PDbUM,
			string PUM,
			string PCoNum,
			int? PCoLine);
	}
}

