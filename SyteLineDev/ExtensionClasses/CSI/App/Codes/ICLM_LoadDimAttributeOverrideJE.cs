//PROJECT NAME: Codes
//CLASS NAME: ICLM_LoadDimAttributeOverrideJE.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_LoadDimAttributeOverrideJE
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LoadDimAttributeOverrideJESp(string Acct = null,
		string SubscriberObjectName = null);
	}
}

