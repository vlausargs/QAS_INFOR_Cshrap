//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTaxInvStaxCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTaxInvStaxCreate
	{
		int? SSSFSTaxInvStaxCreateSp(
			string InvNum,
			int? InvSeq,
			DateTime? InvDate,
			string CustNum,
			int? CustSeq);
	}
}

