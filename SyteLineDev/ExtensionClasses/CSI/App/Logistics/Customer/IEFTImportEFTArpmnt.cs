//PROJECT NAME: Logistics
//CLASS NAME: IEFTImportEFTArpmnt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEFTImportEFTArpmnt
	{
		(int? ReturnCode, decimal? BatchId,
		int? HeaderNum,
		Guid? RefRowPointer,
		string Infobar) EFTImportEFTArpmntSp(string MapId,
		string Filename,
		string CustNum,
		string CustName,
		string CheckNum,
		DateTime? DepositDate,
		decimal? CheckAmt,
		string RoutingNum,
		string AccountNum,
		string PaymentType,
		string Stat,
		decimal? BatchId,
		int? HeaderNum,
		Guid? RefRowPointer,
		string Infobar);
	}
}

