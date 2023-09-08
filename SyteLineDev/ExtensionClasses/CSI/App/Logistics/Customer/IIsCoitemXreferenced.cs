//PROJECT NAME: Logistics
//CLASS NAME: IIsCoitemXreferenced.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsCoitemXreferenced
	{
		(int? ReturnCode, int? PXreferenced) IsCoitemXreferencedSp(string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PXreferenced);
	}
}

