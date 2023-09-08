//PROJECT NAME: Data
//CLASS NAME: IGetRmaitemLinePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetRmaitemLinePrice
	{
		(int? ReturnCode,
			decimal? RmaitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount) GetRmaitemLinePriceSp(
			string RmaNum,
			int? RmaitemRmaLine,
			string RmaitemItem,
			decimal? RmaitemQtyToReturn,
			decimal? RmaitemUnitCredit,
			decimal? RmaitemRestockFeeAmt,
			decimal? RmaitemQtyReceived,
			decimal? RmaitemQtyCredited,
			string RmaitemTaxCode1,
			string RmaitemTaxCode2,
			Guid? RmaitemRowPointer,
			decimal? RmaitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount = null);
	}
}

