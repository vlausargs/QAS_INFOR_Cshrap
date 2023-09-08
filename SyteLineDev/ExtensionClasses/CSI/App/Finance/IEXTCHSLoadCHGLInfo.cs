//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSLoadCHGLInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IEXTCHSLoadCHGLInfo
	{
		(int? ReturnCode, string CHVounum,
		int? LineNum,
		int? Rubric) EXTCHSLoadCHGLInfoSp(string Id,
		int? Seq,
		string CHVounum,
		int? LineNum,
		int? Rubric);
	}
}

