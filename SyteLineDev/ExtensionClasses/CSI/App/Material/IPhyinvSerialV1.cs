//PROJECT NAME: Material
//CLASS NAME: IPhyinvSerialV1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvSerialV1
	{
		(int? ReturnCode, int? SerialEnable,
		string Infobar) PhyinvSerialV1Sp(string Item,
		string Lot,
		string SerNum,
		int? LotTracked,
		int? SerialEnable,
		string Infobar,
		string ImportDocId);
	}
}

