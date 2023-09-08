//PROJECT NAME: Logistics
//CLASS NAME: IARFinChgPostCreateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinChgPostCreateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ARFinChgPostCreateTTSp(string PStartingCustNum,
		string PEndingCustNum,
		Guid? PSessionID);
	}
}

