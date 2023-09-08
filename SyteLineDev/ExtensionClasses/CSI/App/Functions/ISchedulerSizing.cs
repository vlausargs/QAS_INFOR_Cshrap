//PROJECT NAME: Data
//CLASS NAME: ISchedulerSizing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISchedulerSizing
	{
		(int? ReturnCode,
			int? Memory,
			int? DiskSpace) SchedulerSizingSp(
			int? AltNo,
			int? Memory,
			int? DiskSpace);
	}
}

