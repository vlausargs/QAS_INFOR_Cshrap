//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFind_Parent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFind_Parent
	{
		(int? ReturnCode,
			int? p_parent_id,
			string p_parent_ser,
			string p_parent_item) SSSFSFind_ParentSp(
			int? p_comp_id,
			int? p_parent_id,
			string p_parent_ser,
			string p_parent_item);
	}
}

