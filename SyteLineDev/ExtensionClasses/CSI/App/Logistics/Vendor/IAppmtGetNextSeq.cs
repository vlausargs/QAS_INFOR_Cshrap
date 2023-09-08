//PROJECT NAME: Logistics
//CLASS NAME: IAppmtGetNextSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtGetNextSeq
	{
		(int? ReturnCode, int? PCheckSeq,
		string Infobar) AppmtGetNextSeqSp(string PVendNum,
		string PBankCode,
		int? PCheckSeq,
		string Infobar);
	}
}

