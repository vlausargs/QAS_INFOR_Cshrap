//PROJECT NAME: Production
//CLASS NAME: IApsSyncApsSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncApsSeq
	{
		int? ApsSyncApsSeqSp(
			Guid? Partition);
	}
}

