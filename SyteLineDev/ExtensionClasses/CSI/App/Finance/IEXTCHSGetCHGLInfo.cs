//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSGetCHGLInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IEXTCHSGetCHGLInfo
	{
		(int? ReturnCode, string CHVounum,
		int? LineNum,
		int? Rubric) EXTCHSGetCHGLInfoSp(decimal? TransNum,
		string CHVounum,
		int? LineNum,
		int? Rubric);
	}
}

