//PROJECT NAME: Data
//CLASS NAME: IGetSqlProductVersionMajor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSqlProductVersionMajor
	{
		(int? ReturnCode,
			int? ProductVersionMajor,
			string Infobar) GetSqlProductVersionMajorSp(
			int? ProductVersionMajor,
			string Infobar);
	}
}

