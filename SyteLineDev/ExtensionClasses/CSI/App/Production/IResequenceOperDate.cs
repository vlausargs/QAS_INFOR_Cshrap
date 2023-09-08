//PROJECT NAME: Production
//CLASS NAME: IResequenceOperDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IResequenceOperDate
	{
		int? ResequenceOperDateSp(string Job,
		int? Suffix,
		int? OperNum,
		DateTime? NewStartDate);
	}
}

