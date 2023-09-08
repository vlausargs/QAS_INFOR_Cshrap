//PROJECT NAME: Data
//CLASS NAME: IConvertTruncate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertTruncate
	{
		string ConvertTruncateFn(
			string Value,
			int? MaxLength,
			int? Truncate);
	}
}

