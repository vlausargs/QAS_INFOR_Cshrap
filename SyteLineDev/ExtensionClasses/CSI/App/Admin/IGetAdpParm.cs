//PROJECT NAME: Admin
//CLASS NAME: IGetAdpParm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IGetAdpParm
	{
		(int? ReturnCode, string InPath,
		string CompanyCode,
		string InFile,
		int? Prenote,
		string Infobar) GetAdpParmSp(string InPath,
		string CompanyCode,
		string InFile,
		int? Prenote,
		string Infobar);
	}
}

