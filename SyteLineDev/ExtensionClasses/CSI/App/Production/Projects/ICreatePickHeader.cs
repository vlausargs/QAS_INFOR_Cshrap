//PROJECT NAME: Production
//CLASS NAME: ICreatePickHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICreatePickHeader
	{
		(int? ReturnCode, int? PackNum,
		string Infobar) CreatePickHeaderSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? CustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		int? DoLines,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		int? PackNum,
		string Infobar);
	}
}

