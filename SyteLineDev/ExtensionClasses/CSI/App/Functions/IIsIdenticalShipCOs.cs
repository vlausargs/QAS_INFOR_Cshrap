//PROJECT NAME: Data
//CLASS NAME: IIsIdenticalShipCOs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsIdenticalShipCOs
	{
		int? IsIdenticalShipCOsFn(
			int? PBatchId);
	}
}

