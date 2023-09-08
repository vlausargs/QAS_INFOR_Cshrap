//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPriorCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPriorCode
	{
		string SSSFSPriorCodeFn(
			string CustNum,
			int? CustSeq,
			string SerNum,
			string Item,
			string IncPriorCode = null,
			DateTime? IncDateTime = null);
	}
}

