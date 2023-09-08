//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetVchProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetVchProceduralMarkings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetVchProceduralMarkingsSp(string SiteRef,
		int? VchNum,
		int? VchSeq);
	}
}

