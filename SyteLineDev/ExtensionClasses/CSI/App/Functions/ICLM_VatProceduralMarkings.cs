//PROJECT NAME: Data
//CLASS NAME: ICLM_VatProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_VatProceduralMarkings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_VatProceduralMarkingsSp(
			DateTime? BeginTaxDate = null,
			DateTime? EndTaxDate = null);
	}
}

