//PROJECT NAME: Data
//CLASS NAME: IFstNin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFstNin
	{
		(int? ReturnCode,
			int? Pos) FstNinSp(
			string Source,
			string Valid,
			int? Pos);
	}
}

