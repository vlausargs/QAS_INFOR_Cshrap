//PROJECT NAME: Data
//CLASS NAME: IEdiInOrderP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInOrderP
	{
		(int? ReturnCode,
			int? PEdiCoCount,
			int? PPostedCount,
			string Infobar) EdiInOrderPSp(
			string PEdiCoNum,
			int? PEdiCoCount,
			int? PPostedCount,
			string Infobar,
			int? AutoPost = 0,
			decimal? ProcessId = null);
	}
}

