//PROJECT NAME: Material
//CLASS NAME: IItemInsUpdValidatorRem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemInsUpdValidatorRem
	{
		(int? ReturnCode, string Infobar) ItemInsUpdValidatorRemSP(string Site,
		string Infobar);
	}
}

