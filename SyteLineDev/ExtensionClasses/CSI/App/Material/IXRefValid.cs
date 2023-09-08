//PROJECT NAME: Material
//CLASS NAME: IXRefValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IXRefValid
	{
		(int? ReturnCode, string Infobar) XRefValidSp(string Item,
		string FrmRefType,
		string FrmRefNum,
		int? FrmRefLineSuf,
		int? FrmRefRelease,
		string Infobar);
	}
}

