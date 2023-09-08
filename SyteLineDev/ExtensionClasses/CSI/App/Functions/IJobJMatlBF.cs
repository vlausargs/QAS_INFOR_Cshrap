//PROJECT NAME: Data
//CLASS NAME: IJobJMatlBF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobJMatlBF
	{
		(int? ReturnCode,
			string PJob,
			int? PSuffix) JobJMatlBFSp(
			string PItem,
			string PLoc,
			string PWhse,
			string PJob,
			int? PSuffix);
	}
}

