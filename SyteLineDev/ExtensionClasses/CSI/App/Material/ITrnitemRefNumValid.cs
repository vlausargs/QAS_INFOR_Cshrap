//PROJECT NAME: Material
//CLASS NAME: ITrnitemRefNumValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrnitemRefNumValid
	{
		(int? ReturnCode, string RefNum,
		string Infobar) TrnitemRefNumValidSp(string RefType,
		string RefNum,
		string Infobar);
	}
}

