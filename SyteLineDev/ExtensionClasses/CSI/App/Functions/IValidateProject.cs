//PROJECT NAME: Data
//CLASS NAME: IValidateProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateProject
	{
		(int? ReturnCode,
			string Infobar) ValidateProjectSp(
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PItem,
			string Infobar);
	}
}

