//PROJECT NAME: Employee
//CLASS NAME: IPreqCre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPreqCre
	{
		(int? ReturnCode, int? I,
		string CurReqNum,
		int? CurReqLine,
		string Infobar) PreqCreSp(string IItem,
		string IWhse,
		string IReqNum,
		decimal? IQtyOrdered,
		DateTime? IDueDate,
		string IRefType,
		string IRefNum,
		int? IRefLineSuf,
		int? IRefRelease,
		string IDesc,
		decimal? ICost,
		string IUM,
		string IVendNum,
		string IManufacturerId = null,
		string IManufacturerItem = null,
		int? I = null,
		string CurReqNum = null,
		int? CurReqLine = null,
		string Infobar = null);
	}
}

