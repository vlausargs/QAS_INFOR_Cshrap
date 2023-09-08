//PROJECT NAME: Logistics
//CLASS NAME: IAddContactToGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAddContactToGroup
	{
		int? AddContactToGroupSp(string ContactId,
		string GroupName,
		string TableName);
	}
}

