//PROJECT NAME: Data
//CLASS NAME: IReadyForPatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReadyForPatch
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ReadyForPatchSp();
	}
}

