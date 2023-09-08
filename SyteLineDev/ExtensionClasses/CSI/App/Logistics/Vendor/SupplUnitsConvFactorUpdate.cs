//PROJECT NAME: Logistics
//CLASS NAME: SupplUnitsConvFactorUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SupplUnitsConvFactorUpdate : ISupplUnitsConvFactorUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public SupplUnitsConvFactorUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SupplUnitsConvFactorUpdateSp(string BegCommCode,
		string EndCommCode,
		int? UpdCoitem,
		int? UpdPoitem,
		int? UpdTrnitem,
		int? UpdRmaitem,
		int? UpdProjmatl)
		{
			CommodityCodeType _BegCommCode = BegCommCode;
			CommodityCodeType _EndCommCode = EndCommCode;
			ListYesNoType _UpdCoitem = UpdCoitem;
			ListYesNoType _UpdPoitem = UpdPoitem;
			ListYesNoType _UpdTrnitem = UpdTrnitem;
			ListYesNoType _UpdRmaitem = UpdRmaitem;
			ListYesNoType _UpdProjmatl = UpdProjmatl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SupplUnitsConvFactorUpdateSp";
				
				appDB.AddCommandParameter(cmd, "BegCommCode", _BegCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCommCode", _EndCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdCoitem", _UpdCoitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdPoitem", _UpdPoitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdTrnitem", _UpdTrnitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdRmaitem", _UpdRmaitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdProjmatl", _UpdProjmatl, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
