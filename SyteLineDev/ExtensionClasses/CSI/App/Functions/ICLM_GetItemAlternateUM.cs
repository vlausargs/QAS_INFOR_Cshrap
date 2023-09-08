//PROJECT NAME: Data
//CLASS NAME: ICLM_GetItemAlternateUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_GetItemAlternateUM
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetItemAlternateUMSp(
			string Item);
	}
}

