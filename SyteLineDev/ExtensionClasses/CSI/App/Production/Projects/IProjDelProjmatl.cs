//PROJECT NAME: Production
//CLASS NAME: IProjDelProjmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjDelProjmatl
	{
		(int? ReturnCode,
			string Infobar) ProjDelProjmatlSp(
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			string Infobar);
	}
}

