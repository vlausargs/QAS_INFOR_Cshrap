//PROJECT NAME: Data
//CLASS NAME: IDelTermAllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDelTermAllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) DelTermAllValidSp(
			string SiteRef,
			string Delterm,
			string Description,
			string Infobar);
	}
}

