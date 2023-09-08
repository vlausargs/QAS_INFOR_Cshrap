//PROJECT NAME: CSIVendor
//CLASS NAME: POLineRelWarehouseChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOLineRelWarehouseChange
	{
		int POLineRelWarehouseChangeSp(string OldWhse,
		                               string NewWhse,
		                               string StartingPONum,
		                               string EndingPONum,
		                               short? StartingPOLine,
		                               short? EndingPOLine,
		                               short? StartingPORelease,
		                               short? EndingPORelease,
		                               string StartingVendor,
		                               string EndingVendor,
		                               ref string Infobar);
	}
	
	public class POLineRelWarehouseChange : IPOLineRelWarehouseChange
	{
		readonly IApplicationDB appDB;
		
		public POLineRelWarehouseChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int POLineRelWarehouseChangeSp(string OldWhse,
		                                      string NewWhse,
		                                      string StartingPONum,
		                                      string EndingPONum,
		                                      short? StartingPOLine,
		                                      short? EndingPOLine,
		                                      short? StartingPORelease,
		                                      short? EndingPORelease,
		                                      string StartingVendor,
		                                      string EndingVendor,
		                                      ref string Infobar)
		{
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			PoNumType _StartingPONum = StartingPONum;
			PoNumType _EndingPONum = EndingPONum;
			PoLineType _StartingPOLine = StartingPOLine;
			PoLineType _EndingPOLine = EndingPOLine;
			PoReleaseType _StartingPORelease = StartingPORelease;
			PoReleaseType _EndingPORelease = EndingPORelease;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POLineRelWarehouseChangeSp";
				
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPONum", _StartingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPONum", _EndingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPOLine", _StartingPOLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPOLine", _EndingPOLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPORelease", _StartingPORelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPORelease", _EndingPORelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
