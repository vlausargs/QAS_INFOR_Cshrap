//PROJECT NAME: Logistics
//CLASS NAME: ICheckOpportunityExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckOpportunityExists
	{
		(int? ReturnCode, string Infobar) CheckOpportunityExistsSp(string OppId,
		string Infobar);
	}
}

