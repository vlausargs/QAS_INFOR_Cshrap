//PROJECT NAME: Material
//CLASS NAME: IValidateProductCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IValidateProductCode
	{
		(int? ReturnCode, string ProductCode,
		string Infobar) ValidateProductCodeSp(string ProductCode,
		string Whse,
		string Infobar,
		string PSite = null);
	}
}

