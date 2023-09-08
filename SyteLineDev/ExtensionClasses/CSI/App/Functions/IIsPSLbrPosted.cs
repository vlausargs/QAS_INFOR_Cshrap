//PROJECT NAME: Data
//CLASS NAME: IIsPSLbrPosted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsPSLbrPosted
	{
		int? IsPSLbrPostedFn(
			string Job,
			int? Suffix,
			string Type);
	}
}

