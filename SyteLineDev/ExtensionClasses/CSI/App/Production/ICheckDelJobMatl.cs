//PROJECT NAME: Production
//CLASS NAME: ICheckDelJobMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckDelJobMatl
	{
		(int? ReturnCode,
		string Infobar) CheckDelJobMatlSp(
			string Job,
			int? Suffix,
			int? OperNum,
			int? AltGroup,
			int? AltGroupRank,
			string Infobar);
	}
}

