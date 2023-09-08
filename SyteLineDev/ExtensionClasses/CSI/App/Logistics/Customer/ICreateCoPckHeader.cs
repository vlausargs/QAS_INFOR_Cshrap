//PROJECT NAME: Logistics
//CLASS NAME: ICreateCoPckHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoPckHeader
	{
		(int? ReturnCode, int? PackNum,
		string Infobar) CreateCoPckHeaderSp(string TPckCall,
		string CoNum,
		string CustNum,
		int? CustSeq,
		string CoitemCustNum,
		int? CoitemCustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? DoLines,
		int? FromCoLine,
		int? ToCoLine,
		int? FromCoRelease,
		int? ToCoRelease,
		DateTime? FromDate,
		DateTime? ToDate,
		string CoLineStat,
		string ProcessId,
		int? PackNum,
		string Infobar,
		int? BatchId = null);
	}
}

