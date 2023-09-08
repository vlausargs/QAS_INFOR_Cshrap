//PROJECT NAME: Logistics
//CLASS NAME: ISchedParseTaskListSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedParseTaskList
	{
		ICollectionLoadResponse SchedParseTaskListSp(
			string List);
	}
}

