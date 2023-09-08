//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ContainerItemsForCompareCoLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ContainerItemsForCompareCoLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ContainerItemsForCompareCoLineSp(string CoNum,
		string ContainerNum,
		string Infobar);
	}
}

