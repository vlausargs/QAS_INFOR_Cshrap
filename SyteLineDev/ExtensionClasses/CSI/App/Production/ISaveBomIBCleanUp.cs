//PROJECT NAME: Production
//CLASS NAME: ISaveBomIBCleanUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISaveBomIBCleanUp
	{
		int? SaveBomIBCleanUpSp(Guid? ProcessId);
	}
}

