//PROJECT NAME: Data
//CLASS NAME: IGetNextProjNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNextProjNum
	{
		(int? ReturnCode,
			string KeyVal,
			string Infobar) GetNextProjNumSp(
			string TableName,
			string ColumnName,
			string Prefix,
			int? KeyLength,
			string KeyVal,
			string Infobar);
	}
}

