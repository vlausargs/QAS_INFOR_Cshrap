//PROJECT NAME: Data
//CLASS NAME: IValidateOCR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateOCR
	{
		int? ValidateOCRSp(
			string StmDocumentID,
			string PartyId,
			decimal? Amount,
			string Modulus);
	}
}

