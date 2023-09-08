//PROJECT NAME: Data
//CLASS NAME: IFmtJobSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IFmtJob
	{
		string FmtJobSp(
			string RefNum,
			int? Suffix);
	}
}

