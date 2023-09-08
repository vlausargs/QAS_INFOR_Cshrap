//PROJECT NAME: Data
//CLASS NAME: ITaskCodeLov.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaskCodeLov
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TaskCodeLovSp(
			string TaskCode = null);
	}
}

