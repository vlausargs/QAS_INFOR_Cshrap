//PROJECT NAME: Production
//CLASS NAME: IProjNextPbol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjNextPbol
	{
		(int? ReturnCode,
			string Key,
			string Infobar) ProjNextPbolSp(
			string ProjNum,
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

