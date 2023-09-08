//PROJECT NAME: Codes
//CLASS NAME: ITaxDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ITaxDesc
	{
		(int? ReturnCode, string PTaxCodeDesc1,
		string PTaxCodeDesc2) TaxDescSp(string PType,
		string PTaxCode1,
		string PTaxCode2,
		string PTaxCodeDesc1,
		string PTaxCodeDesc2);
	}
}

