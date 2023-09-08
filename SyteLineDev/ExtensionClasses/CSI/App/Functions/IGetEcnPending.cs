//PROJECT NAME: Data
//CLASS NAME: IGetEcnPending.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEcnPending
	{
		string GetEcnPendingFn(
			string Job,
			int? Suffix,
			string Item,
			string Revision);
	}
}

