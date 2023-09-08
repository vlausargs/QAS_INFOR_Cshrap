//PROJECT NAME: Finance
//CLASS NAME: IArtranUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArtranUpd
	{
		int? ArtranUpdSp(
			Guid? RowPointer,
			string Type,
			string CustNum,
			string InvNum,
			int? InvSeq,
			int? CheckSeq,
			string CoNum,
			string Description,
			int? Active,
			DateTime? DueDate,
			DateTime? InvDate,
			DateTime? DiscDate,
			string ApplyToInvNum,
			DateTime? InvHdrTaxDate,
			decimal? ExchRate);
	}
}

