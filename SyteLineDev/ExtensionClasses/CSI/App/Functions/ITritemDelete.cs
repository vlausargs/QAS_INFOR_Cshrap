//PROJECT NAME: Data
//CLASS NAME: ITritemDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITritemDelete
	{
		(int? ReturnCode,
			string Infobar) TritemDeleteSp(
			string PTrnNum,
			int? PTrnLine,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null);
	}
}

