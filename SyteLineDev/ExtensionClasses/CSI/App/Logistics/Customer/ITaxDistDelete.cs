//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxDistDelete
	{
		(int? ReturnCode, string Infobar) TaxDistDeleteSp(Guid? PRowPointer,
		string PCoNum,
		int? PSeq,
		string Infobar);
	}
}

