//PROJECT NAME: Logistics
//CLASS NAME: ICLM_InvAdjLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_InvAdjLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InvAdjLoadSp(string PrevCoNum,
		string PCoNum,
		string PApplyToInvNum,
		decimal? UserId,
		string Filter = null);
	}
}

