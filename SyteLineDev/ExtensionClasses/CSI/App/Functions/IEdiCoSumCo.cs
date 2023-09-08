//PROJECT NAME: Data
//CLASS NAME: IEdiCoSumCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiCoSumCo
	{
		(int? ReturnCode,
			string Infobar) EdiCoSumCoSp(
			string PCoNum,
			string Infobar);
	}
}

