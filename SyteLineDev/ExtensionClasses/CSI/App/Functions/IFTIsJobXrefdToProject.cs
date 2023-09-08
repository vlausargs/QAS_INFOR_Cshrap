//PROJECT NAME: Data
//CLASS NAME: IFTIsJobXrefdToProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTIsJobXrefdToProject
	{
		int? FTIsJobXrefdToProjectFn(
			string pJob,
			int? pSuffix,
			int? CheckRootJob,
			int? CheckJobStatus);
	}
}

