//PROJECT NAME: Data
//CLASS NAME: IValidateTermsDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateTermsDel
	{
		(int? ReturnCode,
			string Infobar) ValidateTermsDelSp(
			string PTermsCode,
			string Infobar);
	}
}

