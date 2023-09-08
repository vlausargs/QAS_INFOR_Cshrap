//PROJECT NAME: Data
//CLASS NAME: ICoStatusValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoStatusValid
	{
		(int? ReturnCode,
			string Infobar) CoStatusValidSp(
			string CoNum,
			string OldStatus,
			string Status,
			string Type,
			string Infobar);
	}
}

