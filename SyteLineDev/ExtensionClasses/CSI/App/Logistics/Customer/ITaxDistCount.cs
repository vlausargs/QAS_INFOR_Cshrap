//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxDistCount
	{
		(int? ReturnCode, int? PDistCount,
		string Infobar) TaxDistCountSp(string PCoNum,
		int? PDistCount,
		string Infobar);
	}
}

