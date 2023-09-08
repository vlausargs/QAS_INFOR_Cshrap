//PROJECT NAME: Data
//CLASS NAME: IFTInsertProject.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTInsertProject
	{
		(int? ReturnCode,
			string Infobar) FTInsertProjectSp(
			Guid? SessionID,
			string Infobar);
	}
}

