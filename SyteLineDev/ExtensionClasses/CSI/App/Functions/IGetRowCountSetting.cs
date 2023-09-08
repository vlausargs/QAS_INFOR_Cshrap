//PROJECT NAME: Data
//CLASS NAME: IGetRowCountSetting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetRowCountSetting
	{
		(int? ReturnCode,
			long? RowCount) GetRowCountSettingSp(
			long? RowCount);
	}
}

