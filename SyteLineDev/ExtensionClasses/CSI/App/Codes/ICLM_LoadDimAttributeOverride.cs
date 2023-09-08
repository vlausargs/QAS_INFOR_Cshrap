//PROJECT NAME: Codes
//CLASS NAME: ICLM_LoadDimAttributeOverride.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_LoadDimAttributeOverride
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_LoadDimAttributeOverrideSp(
			string Acct = null,
			string SubscriberObjectName = null,
			Guid? SubscriberObjectRowPointer = null);
	}
}

