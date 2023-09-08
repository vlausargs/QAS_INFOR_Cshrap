//PROJECT NAME: Material
//CLASS NAME: IBolItemSetGloVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBolItemSetGloVar
	{
		int? BolItemSetGloVarSp(int? UpdateASNWeight,
		int? UpdateASNCharges);
	}
}

