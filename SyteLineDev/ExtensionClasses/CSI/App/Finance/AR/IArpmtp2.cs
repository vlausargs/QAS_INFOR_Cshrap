//PROJECT NAME: Finance
//CLASS NAME: IArpmtp2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtp2
	{
		(int? ReturnCode,
			string Infobar) Arpmtp2Sp(
			Guid? PArpmtRowPointer,
			string Infobar,
			Guid? PProcessId);
	}
}

