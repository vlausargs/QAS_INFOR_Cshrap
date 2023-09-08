//PROJECT NAME: Data
//CLASS NAME: IClrXparBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClrXparBulk
	{
		(int? ReturnCode,
			string Infobar) ClrXparBulkSp(
			Guid? ProcessId,
			string Infobar);
	}
}

