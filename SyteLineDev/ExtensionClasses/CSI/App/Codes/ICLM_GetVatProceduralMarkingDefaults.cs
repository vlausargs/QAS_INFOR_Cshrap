//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetVatProceduralMarkingDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetVatProceduralMarkingDefaults
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetVatProceduralMarkingDefaultsSp(string RefNum,
		string RefType,
		string Infobar);
	}
}

