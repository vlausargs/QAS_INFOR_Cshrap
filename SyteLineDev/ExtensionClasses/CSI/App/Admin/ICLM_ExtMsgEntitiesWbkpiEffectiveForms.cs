//PROJECT NAME: Admin
//CLASS NAME: ICLM_ExtMsgEntitiesWbkpiEffectiveForms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_ExtMsgEntitiesWbkpiEffectiveForms
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExtMsgEntitiesWbkpiEffectiveFormsSp(string ExtMsgEntity = null);
	}
}

