//PROJECT NAME: CSIVendor
//CLASS NAME: POHeaderWarehouseChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOHeaderWarehouseChange
	{
		int POHeaderWarehouseChangeSp(string StartingPONum,
		                              string EndingPONum,
		                              string OldWhse,
		                              string NewWhse,
		                              ref string Infobar);
	}
	
	public class POHeaderWarehouseChange : IPOHeaderWarehouseChange
	{
		readonly IApplicationDB appDB;
		
		public POHeaderWarehouseChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int POHeaderWarehouseChangeSp(string StartingPONum,
		                                     string EndingPONum,
		                                     string OldWhse,
		                                     string NewWhse,
		                                     ref string Infobar)
		{
			PoNumType _StartingPONum = StartingPONum;
			PoNumType _EndingPONum = EndingPONum;
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POHeaderWarehouseChangeSp";
				
				appDB.AddCommandParameter(cmd, "StartingPONum", _StartingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPONum", _EndingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
