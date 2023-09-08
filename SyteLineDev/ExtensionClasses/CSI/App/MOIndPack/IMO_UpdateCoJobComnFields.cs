//PROJECT NAME: MOIndPack
//CLASS NAME: IMO_UpdateCoJobComnFields.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMO_UpdateCoJobComnFields
	{
		int? MO_UpdateCoJobComnFieldsSp(
			string Job,
			string JobDescription,
			string JobType,
			string Whse,
			string JobStatus,
			string EstJob,
			DateTime? JobDate,
			DateTime? JobStart,
			int? JobPriority,
			int? PriorityFreeze,
			int? ProductCycle);
	}
}

