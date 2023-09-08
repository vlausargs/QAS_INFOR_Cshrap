//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSValidSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSValidSeq
	{
		(int? ReturnCode, string Infobar) SSSFSValidSeqSp(string CustNum,
		int? CustSeq,
		string Infobar);
	}
}

