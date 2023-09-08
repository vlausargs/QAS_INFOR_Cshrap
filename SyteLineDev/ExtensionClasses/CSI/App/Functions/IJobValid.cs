//PROJECT NAME: Data
//CLASS NAME: IJobValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobValid
	{
		(int? ReturnCode,
			string Infobar) JobValidSp(
			string JobJob = null,
			int? JobSuffix = null,
			string Site = null,
			string Infobar = null);
	}
}

