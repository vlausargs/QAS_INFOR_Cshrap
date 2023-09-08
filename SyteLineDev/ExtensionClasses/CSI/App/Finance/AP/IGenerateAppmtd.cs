//PROJECT NAME: Finance
//CLASS NAME: IGenerateAppmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IGenerateAppmtd
	{
		(int? ReturnCode,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar) GenerateAppmtdSp(
			Guid? PSessionId,
			Guid? PAppmtRowid,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar);
	}
}

