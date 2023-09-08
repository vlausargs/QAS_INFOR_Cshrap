//PROJECT NAME: Material
//CLASS NAME: IInputUpdateSheetsItemVerify.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IInputUpdateSheetsItemVerify
	{
		(int? ReturnCode, string Infobar) InputUpdateSheetsItemVerifySp(string Item,
		string Infobar);
	}
}

