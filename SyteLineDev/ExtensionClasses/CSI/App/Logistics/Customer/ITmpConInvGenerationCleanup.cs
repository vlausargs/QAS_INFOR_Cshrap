//PROJECT NAME: Logistics
//CLASS NAME: ITmpConInvGenerationCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITmpConInvGenerationCleanup
	{
		int? TmpConInvGenerationCleanupSp(
			Guid? ProcessId);
	}
}

