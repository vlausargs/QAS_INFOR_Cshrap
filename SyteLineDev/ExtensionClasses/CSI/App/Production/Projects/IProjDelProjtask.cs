//PROJECT NAME: Production
//CLASS NAME: IProjDelProjtask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjDelProjtask
	{
		(int? ReturnCode,
			string Infobar) ProjDelProjtaskSp(
			string ProjNum,
			int? TaskNum,
			string Infobar);
	}
}

