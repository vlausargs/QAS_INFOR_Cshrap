//PROJECT NAME: Data
//CLASS NAME: IEdiSumCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiSumCo
	{
		(int? ReturnCode,
			string Infobar) EdiSumCoSp(
			string CoNum,
			string Infobar);
	}
}

