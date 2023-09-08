//PROJECT NAME: Logistics
//CLASS NAME: IGetPoDropShipData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetPoDropShipData
	{
		(int? ReturnCode, string DropShipName,
		string DropShipAddr1,
		string DropShipAddr2,
		string DropShipAddr3,
		string DropShipAddr4,
		string DropShipCity,
		string DropShipState,
		string DropShipCounty,
		string DropShipCountry,
		string DropShipZip,
		string DropShipContact,
		string DropShipPhone,
		string DropShipFaxNum,
		string DropShipExtEmail,
		string Infobar) GetPoDropShipDataSp(string PoDropShipNo,
		int? PoDropSeq,
		string PoShipAddr,
		string DropShipName,
		string DropShipAddr1,
		string DropShipAddr2,
		string DropShipAddr3,
		string DropShipAddr4,
		string DropShipCity,
		string DropShipState,
		string DropShipCounty,
		string DropShipCountry,
		string DropShipZip,
		string DropShipContact,
		string DropShipPhone,
		string DropShipFaxNum,
		string DropShipExtEmail,
		string Infobar);
	}
}

