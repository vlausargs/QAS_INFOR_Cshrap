//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContItemAvailItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContItemAvailItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSContItemAvailItemsSp(string Whse,
		string Item,
		string FilterString = null);
	}
}

