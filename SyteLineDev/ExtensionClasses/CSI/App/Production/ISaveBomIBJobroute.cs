//PROJECT NAME: Production
//CLASS NAME: ISaveBomIBJobroute.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISaveBomIBJobroute
	{
		int? SaveBomIBJobrouteSp(Guid? ProcessId,
		string Job,
		int? Suffix,
		int? OperNum,
		string Wc,
		string WcDescription);
	}
}

