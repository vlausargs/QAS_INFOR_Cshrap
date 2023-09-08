//PROJECT NAME: Data
//CLASS NAME: ICreateProdMixTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateProdMixTT
	{
		(int? ReturnCode,
			string Infobar) CreateProdMixTTSp(
			Guid? PSessionID,
			string Infobar);
	}
}

