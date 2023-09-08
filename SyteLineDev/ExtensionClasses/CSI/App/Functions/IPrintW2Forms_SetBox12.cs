//PROJECT NAME: Data
//CLASS NAME: IPrintW2Forms_SetBox12.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrintW2Forms_SetBox12
	{
		(int? ReturnCode,
			int? ie,
			string t_box12__1,
			string t_box12__2,
			string t_box12__3,
			string t_box12__4,
			decimal? t_box12_itemz__1,
			decimal? t_box12_itemz__2,
			decimal? t_box12_itemz__3,
			decimal? t_box12_itemz__4) PrintW2Forms_SetBox12Sp(
			int? index,
			int? ie,
			string t_box12__1,
			string t_box12__2,
			string t_box12__3,
			string t_box12__4,
			decimal? t_box12_itemz__1,
			decimal? t_box12_itemz__2,
			decimal? t_box12_itemz__3,
			decimal? t_box12_itemz__4,
			decimal? t_itemz);
	}
}

