//PROJECT NAME: Data
//CLASS NAME: IVoidDrf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVoidDrf
	{
		(int? ReturnCode,
			string Infobar) VoidDrfSp(
			string PBankCode,
			string PCurBankCode = null,
			int? PCheckNum = null,
			int? PProcessFlag = 0,
			string Infobar = null);
	}
}

