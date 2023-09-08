//PROJECT NAME: Codes
//CLASS NAME: IPmfInitUm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IPmfInitUm
	{
		(int? ReturnCode,
		string Infobar) PmfInitUmSp(
			string Infobar = null);
	}
}

