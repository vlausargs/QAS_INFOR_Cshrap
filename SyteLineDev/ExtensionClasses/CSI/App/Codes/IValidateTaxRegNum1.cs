//PROJECT NAME: Codes
//CLASS NAME: IValidateTaxRegNum1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IValidateTaxRegNum1
	{
		(int? ReturnCode, string Infobar) ValidateTaxRegNum1Sp(string FormType,
		string Infobar);
	}
}

