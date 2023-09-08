//PROJECT NAME: Data
//CLASS NAME: IFTIsMaterialTiedToProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTIsMaterialTiedToProject
	{
		int? FTIsMaterialTiedToProjectFn(
			string pJob,
			int? pSuffix,
			int? pOperNum,
			int? pSequence,
			int? CheckIfSuppliedBySubJob,
			int? CheckJobStatus);
	}
}

