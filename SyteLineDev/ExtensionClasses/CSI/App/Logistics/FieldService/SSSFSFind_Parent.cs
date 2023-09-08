//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFind_Parent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFind_Parent : ISSSFSFind_Parent
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFind_Parent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? p_parent_id,
			string p_parent_ser,
			string p_parent_item) SSSFSFind_ParentSp(
			int? p_comp_id,
			int? p_parent_id,
			string p_parent_ser,
			string p_parent_item)
		{
			FSCompIdType _p_comp_id = p_comp_id;
			FSCompIdType _p_parent_id = p_parent_id;
			SerNumType _p_parent_ser = p_parent_ser;
			ItemType _p_parent_item = p_parent_item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSFind_ParentSp";
				
				appDB.AddCommandParameter(cmd, "p_comp_id", _p_comp_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_parent_id", _p_parent_id, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_parent_ser", _p_parent_ser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_parent_item", _p_parent_item, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_parent_id = _p_parent_id;
				p_parent_ser = _p_parent_ser;
				p_parent_item = _p_parent_item;
				
				return (Severity, p_parent_id, p_parent_ser, p_parent_item);
			}
		}
	}
}
