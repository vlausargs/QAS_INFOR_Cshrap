//PROJECT NAME: Logistics
//CLASS NAME: IAppmtdGetNextSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtdGetNextSequence
	{
		(int? ReturnCode,
			int? PSeq,
			string Infobar) AppmtdGetNextSequenceSp(
			string PVendNum,
			string PBankCode,
			int? PCheckSeq,
			int? PSeq,
			string Infobar);
	}
}

