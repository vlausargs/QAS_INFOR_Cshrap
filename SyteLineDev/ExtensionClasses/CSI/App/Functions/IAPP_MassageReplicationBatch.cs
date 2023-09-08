//PROJECT NAME: Data
//CLASS NAME: IAPP_MassageReplicationBatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_MassageReplicationBatch
	{
		int? APP_MassageReplicationBatchSp(
			Guid? ProcessingPtr);
	}
}

