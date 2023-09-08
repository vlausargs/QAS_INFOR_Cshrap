//PROJECT NAME: Data
//CLASS NAME: ITranslateBODCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITranslateBODCust
	{
		(int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string Infobar) TranslateBODCustSp(
			string CustomerID,
			string CustNum,
			int? CustSeq,
			string Infobar);
	}
}

