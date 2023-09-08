//PROJECT NAME: Material
//CLASS NAME: IValidateCreateTagExtract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IValidateCreateTagExtract
	{
		(int? ReturnCode, string Infobar) ValidateCreateTagExtractSp(string Whse,
		string Infobar);
	}
}

