//PROJECT NAME: Production
//CLASS NAME: IProjLabrTaskNumValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjLabrTaskNumValid
	{
		(int? ReturnCode,
			string TaskDesc,
			string Infobar) ProjLabrTaskNumValidSp(
			string ProjNum,
			int? TaskNum,
			string TaskDesc,
			string Infobar);
	}
}

