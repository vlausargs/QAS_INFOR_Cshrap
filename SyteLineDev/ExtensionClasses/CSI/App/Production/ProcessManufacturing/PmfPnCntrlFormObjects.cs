//PROJECT NAME: Production
//CLASS NAME: PmfPnCntrlFormObjects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnCntrlFormObjects : IPmfPnCntrlFormObjects
	{
		readonly IApplicationDB appDB;
		
		public PmfPnCntrlFormObjects(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? hide_check_box,
			int? no_select_qty_ord) PmfPnCntrlFormObjectsSp(
			Guid? mf_spec_rp,
			int? pn_size_method,
			int? hide_check_box,
			int? no_select_qty_ord)
		{
			GuidType _mf_spec_rp = mf_spec_rp;
			ShortType _pn_size_method = pn_size_method;
			ByteType _hide_check_box = hide_check_box;
			ByteType _no_select_qty_ord = no_select_qty_ord;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnCntrlFormObjectsSp";
				
				appDB.AddCommandParameter(cmd, "mf_spec_rp", _mf_spec_rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pn_size_method", _pn_size_method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "hide_check_box", _hide_check_box, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "no_select_qty_ord", _no_select_qty_ord, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				hide_check_box = _hide_check_box;
				no_select_qty_ord = _no_select_qty_ord;
				
				return (Severity, hide_check_box, no_select_qty_ord);
			}
		}
	}
}
