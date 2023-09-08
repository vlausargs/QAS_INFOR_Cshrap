//PROJECT NAME: Codes
//CLASS NAME: ICountTasksAndMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICountTasksAndMessages
	{
		(int? ReturnCode, int? NumberOfUserTasks,
		int? NumberOfEventMessages) CountTasksAndMessagesSp(int? NumberOfUserTasks,
		int? NumberOfEventMessages);
	}
}

