//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetInvProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetInvProceduralMarkings
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetInvProceduralMarkingsSp(
			string InvNum,
			int? InvSeq,
			string SiteRef);
	}
}

