//PROJECT NAME: Data
//CLASS NAME: IFetchPreassignedSerials.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFetchPreassignedSerials
	{
		int? FetchPreassignedSerialsSp(
			string Item,
			string Prefix,
			int? Qty,
			string Site = null);
	}
}

