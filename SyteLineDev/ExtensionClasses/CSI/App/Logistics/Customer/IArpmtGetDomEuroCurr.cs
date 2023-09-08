//PROJECT NAME: Logistics
//CLASS NAME: IArpmtGetDomEuroCurr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtGetDomEuroCurr
	{
		(int? ReturnCode, string PEuroCurr,
		int? PDomOfEuro) ArpmtGetDomEuroCurrSp(string PDomCurr,
		string PEuroCurr,
		int? PDomOfEuro);
	}
}

