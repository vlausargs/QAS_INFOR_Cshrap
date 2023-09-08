//PROJECT NAME: Production
//CLASS NAME: IProjLabrProjNumValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjLabrProjNumValid
	{
		(int? ReturnCode,
			string ProjDesc,
			string Infobar) ProjLabrProjNumValidSp(
			string ProjNum,
			string ProjDesc,
			string Infobar);
	}
}

