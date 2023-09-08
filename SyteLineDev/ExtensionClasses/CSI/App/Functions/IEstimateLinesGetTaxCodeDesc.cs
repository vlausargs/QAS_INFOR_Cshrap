//PROJECT NAME: Data
//CLASS NAME: IEstimateLinesGetTaxCodeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEstimateLinesGetTaxCodeDesc
	{
		(int? ReturnCode,
			string PTaxDesc1,
			string PTaxDesc2) EstimateLinesGetTaxCodeDescSp(
			string PTaxCode1,
			string PTaxCode2,
			string PTaxDesc1,
			string PTaxDesc2);
	}
}

