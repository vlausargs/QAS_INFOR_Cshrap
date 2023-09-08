//PROJECT NAME: Data
//CLASS NAME: ICreateJobItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateJobItem
	{
		(int? ReturnCode,
			string Infobar) CreateJobItemSp(
			string PJob,
			int? PSuffix,
			string Infobar);
	}
}

