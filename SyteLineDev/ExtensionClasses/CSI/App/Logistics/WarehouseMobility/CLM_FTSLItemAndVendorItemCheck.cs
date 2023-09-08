//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: CLM_FTSLItemAndVendorItemCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLItemAndVendorItemCheck
	{
		int CLM_FTSLItemAndVendorItemCheckSp(string PoReceiptType,
		                                     string PoNum,
		                                     string VendorNum,
		                                     string GrnNum,
		                                     string GrnLine,
		                                     string VendorItem,
		                                     ref string InfoBar);
	}
	
	public class CLM_FTSLItemAndVendorItemCheck : ICLM_FTSLItemAndVendorItemCheck
	{
		readonly IApplicationDB appDB;
		
		public CLM_FTSLItemAndVendorItemCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CLM_FTSLItemAndVendorItemCheckSp(string PoReceiptType,
		                                            string PoNum,
		                                            string VendorNum,
		                                            string GrnNum,
		                                            string GrnLine,
		                                            string VendorItem,
		                                            ref string InfoBar)
		{
			EmpNumType _PoReceiptType = PoReceiptType;
			PoNumType _PoNum = PoNum;
			EmpNumType _VendorNum = VendorNum;
			ItemType _GrnNum = GrnNum;
			EmpNumType _GrnLine = GrnLine;
			ItemType _VendorItem = VendorItem;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLItemAndVendorItemCheckSp";
				
				appDB.AddCommandParameter(cmd, "PoReceiptType", _PoReceiptType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorNum", _VendorNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnLine", _GrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorItem", _VendorItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
