//PROJECT NAME: Data
//CLASS NAME: IAPP_SharedTableTriggerList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_SharedTableTriggerList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) APP_SharedTableTriggerListSp();
	}
}

