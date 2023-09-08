//PROJECT NAME: Data
//CLASS NAME: IIsSubJobTiedToProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsSubJobTiedToProject
	{
		int? IsSubJobTiedToProjectFn(
			string pJob,
			int? pSuffix,
			int? CheckJobStatus);
	}
}

