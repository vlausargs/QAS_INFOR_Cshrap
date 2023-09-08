//PROJECT NAME: Data
//CLASS NAME: IInsertVchDistProceduralMarking.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInsertVchDistProceduralMarking
	{
		(int? ReturnCode,
			string Infobar) InsertVchDistProceduralMarkingSp(
			int? Voucher,
			int? VoucherSeq,
			string VendNum,
			string Type,
			string TaxCode,
			string TaxCodeE,
			string Infobar);
	}
}

