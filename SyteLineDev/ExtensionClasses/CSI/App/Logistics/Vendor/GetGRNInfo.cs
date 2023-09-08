//PROJECT NAME: CSIVendor
//CLASS NAME: GetGRNInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetGRNInfo
	{
		int GetGRNInfoSp(string VendNum,
		                 string GrnNum,
		                 ref string GrnStat,
		                 ref DateTime? GrnHdrDate,
		                 ref DateTime? GrnShippedDate,
		                 ref string VendName,
		                 ref string Whse,
		                 ref string WhseName,
		                 ref string Infobar);
	}
	
	public class GetGRNInfo : IGetGRNInfo
	{
		readonly IApplicationDB appDB;
		
		public GetGRNInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetGRNInfoSp(string VendNum,
		                        string GrnNum,
		                        ref string GrnStat,
		                        ref DateTime? GrnHdrDate,
		                        ref DateTime? GrnShippedDate,
		                        ref string VendName,
		                        ref string Whse,
		                        ref string WhseName,
		                        ref string Infobar)
		{
			VendNumType _VendNum = VendNum;
			GrnNumType _GrnNum = GrnNum;
			GrnStatusType _GrnStat = GrnStat;
			DateType _GrnHdrDate = GrnHdrDate;
			DateType _GrnShippedDate = GrnShippedDate;
			NameType _VendName = VendName;
			WhseType _Whse = Whse;
			NameType _WhseName = WhseName;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetGRNInfoSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnStat", _GrnStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GrnHdrDate", _GrnHdrDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GrnShippedDate", _GrnShippedDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendName", _VendName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseName", _WhseName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GrnStat = _GrnStat;
				GrnHdrDate = _GrnHdrDate;
				GrnShippedDate = _GrnShippedDate;
				VendName = _VendName;
				Whse = _Whse;
				WhseName = _WhseName;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
