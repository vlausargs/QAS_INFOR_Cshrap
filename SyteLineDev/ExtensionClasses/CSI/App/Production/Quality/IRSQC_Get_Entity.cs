//PROJECT NAME: Production
//CLASS NAME: IRSQC_Get_Entity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_Get_Entity
	{
		string RSQC_Get_EntityFn(
			string i_ref_type,
			string i_ref_num,
			int? i_ref_line,
			string i_entity);
	}
}

