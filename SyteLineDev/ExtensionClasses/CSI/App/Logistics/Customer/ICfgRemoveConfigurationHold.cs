//PROJECT NAME: Logistics
//CLASS NAME: ICfgRemoveConfigurationHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICfgRemoveConfigurationHold
	{
		int? CfgRemoveConfigurationHoldSp(string SourceRefType,
		string RefNum,
		int? RefLineSuf,
		int? ConfigHold);
	}
}

