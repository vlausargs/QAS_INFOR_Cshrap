//PROJECT NAME: Production
//CLASS NAME: IGetBATPRODID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IGetBATPRODID
	{
		(int? ReturnCode, int? BatchedProdId) GetBATPRODIDSp(int? AltNo,
		int? BatchedProdId);
	}
}

