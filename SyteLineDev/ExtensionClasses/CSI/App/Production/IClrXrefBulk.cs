//PROJECT NAME: Production
//CLASS NAME: IClrXrefBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IClrXrefBulk
	{
		(int? ReturnCode,
			string Infobar) ClrXrefBulkSp(
			Guid? ProcessId,
			string Infobar);
	}
}

