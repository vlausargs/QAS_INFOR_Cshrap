//PROJECT NAME: Logistics
//CLASS NAME: ICoPackingSlipLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoPackingSlipLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CoPackingSlipLoadSp(string TPckCall,
		string CoNum,
		string CustNum,
		string CoitemCustNum,
		int? CoitemCustSeq,
		string Whse,
		int? FromCoLine,
		int? ToCoLine,
		int? FromCoRelease,
		int? ToCoRelease,
		DateTime? FromDate,
		DateTime? ToDate,
		string Stat,
		int? BatchId = null,
		string FilterString = null);
	}
}

