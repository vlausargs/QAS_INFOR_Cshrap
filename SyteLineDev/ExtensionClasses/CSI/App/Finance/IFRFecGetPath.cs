//PROJECT NAME: Finance
//CLASS NAME: IFRFecGetPath.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFRFecGetPath
	{
		(int? ReturnCode, string PPath,
		string PFedId,
		string Infobar) FRFecGetPathSp(string PPath,
		string PFedId,
		string Infobar);
	}
}

