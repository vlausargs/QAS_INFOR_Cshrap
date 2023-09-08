//PROJECT NAME: Data
//CLASS NAME: IPRIOR_TO_FEATURE_RS9071_GenerateArpmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRIOR_TO_FEATURE_RS9071_GenerateArpmtd
	{
		(int? ReturnCode,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar) PRIOR_TO_FEATURE_RS9071_GenerateArpmtdSp(
			Guid? PArpmtRowid,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar,
			Guid? PProcessId);
	}
}

