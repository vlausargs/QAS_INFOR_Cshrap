//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateCar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateCar
	{
		(int? ReturnCode, string o_car,
		string Infobar) RSQC_CreateCarSp(string i_mrr,
		string i_crcvr,
		string i_trcvr,
		string i_car,
		string o_car,
		string Infobar);
	}
}

