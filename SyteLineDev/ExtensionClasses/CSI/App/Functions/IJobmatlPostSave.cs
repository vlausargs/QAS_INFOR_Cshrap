//PROJECT NAME: Data
//CLASS NAME: IJobmatlPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobmatlPostSave
	{
		(int? ReturnCode,
			string Infobar) JobmatlPostSaveSp(
			string Infobar);
	}
}

