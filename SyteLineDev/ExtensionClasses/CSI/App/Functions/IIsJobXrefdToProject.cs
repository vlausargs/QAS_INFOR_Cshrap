//PROJECT NAME: Data
//CLASS NAME: IIsJobXrefdToProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsJobXrefdToProject
	{
		int? IsJobXrefdToProjectFn(
			string pJob,
			int? pSuffix,
			int? CheckRootJob,
			int? CheckJobStatus);
	}
}

