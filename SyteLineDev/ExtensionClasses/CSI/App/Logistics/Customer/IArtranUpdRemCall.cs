//PROJECT NAME: Logistics
//CLASS NAME: IArtranUpdRemCall.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArtranUpdRemCall
	{
		int? ArtranUpdRemCallSp(string Site,
		Guid? RowPointer,
		string ArtranType,
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

