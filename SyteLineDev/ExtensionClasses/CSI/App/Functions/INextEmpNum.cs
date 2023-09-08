//PROJECT NAME: Data
//CLASS NAME: INextEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextEmpNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextEmpNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

