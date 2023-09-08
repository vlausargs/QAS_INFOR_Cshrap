//PROJECT NAME: Data
//CLASS NAME: ICoNextBol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoNextBol
	{
		(int? ReturnCode,
			string Key,
			string Infobar) CoNextBolSp(
			string TrnNum,
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

