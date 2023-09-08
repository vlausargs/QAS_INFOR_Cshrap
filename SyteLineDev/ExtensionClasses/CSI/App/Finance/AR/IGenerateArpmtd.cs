//PROJECT NAME: Finance
//CLASS NAME: IGenerateArpmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IGenerateArpmtd
	{
		(int? ReturnCode,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar) GenerateArpmtdSp(
			Guid? PArpmtRowid,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar,
			Guid? PProcessId);
	}
}

