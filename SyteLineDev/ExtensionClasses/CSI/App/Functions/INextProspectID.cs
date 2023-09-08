//PROJECT NAME: Data
//CLASS NAME: INextProspectID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextProspectID
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextProspectIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

