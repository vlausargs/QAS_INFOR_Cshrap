//PROJECT NAME: Data
//CLASS NAME: IPPSRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPPSRef
	{
		string PPSRefFn(
			string job,
			int? suffix);
	}
}

