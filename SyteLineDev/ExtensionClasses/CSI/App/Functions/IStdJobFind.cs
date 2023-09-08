//PROJECT NAME: Data
//CLASS NAME: IStdJobFind.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IStdJobFind
	{
		Guid? StdJobFindFn(
			string Job,
			int? OperNum,
			string Item,
			decimal? MatlQty);
	}
}

