//PROJECT NAME: Codes
//CLASS NAME: IVatProceduralMarkingDefaultsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IVatProceduralMarkingDefaultsUpd
	{
		(int? ReturnCode, string Infobar) VatProceduralMarkingDefaultsUpdSp(int? Select,
		string RefNum,
		string RefType,
		string ProcMarKingId,
		string Infobar = null);
	}
}

