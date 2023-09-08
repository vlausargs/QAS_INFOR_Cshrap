//PROJECT NAME: Logistics
//CLASS NAME: IARDistribDomAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARDistribDomAmts
	{
		(int? ReturnCode, string Infobar) ARDistribDomAmtsSp(Guid? pRowPointer,
		string Infobar);
	}
}

