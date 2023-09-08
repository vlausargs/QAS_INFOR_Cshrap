//PROJECT NAME: Logistics
//CLASS NAME: IVerifyCustSeqDoesNotExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IVerifyCustSeqDoesNotExist
	{
		(int? ReturnCode, string Infobar) VerifyCustSeqDoesNotExistSp(string CustNum,
		int? CustSeq,
		string Infobar);
	}
}

