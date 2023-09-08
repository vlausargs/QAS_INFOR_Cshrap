//PROJECT NAME: CSIVendor
//CLASS NAME: GrnDelUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGrnDelUtil
	{
		int GrnDelUtilSp(string GrnStat,
		                 string StartGrnNum,
		                 string EndGrnNum,
		                 string StartVendNum,
		                 string EndVendNum,
		                 ref int? GrnsDeleted,
		                 ref string Infobar);
	}
	
	public class GrnDelUtil : IGrnDelUtil
	{
		readonly IApplicationDB appDB;
		
		public GrnDelUtil(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GrnDelUtilSp(string GrnStat,
		                        string StartGrnNum,
		                        string EndGrnNum,
		                        string StartVendNum,
		                        string EndVendNum,
		                        ref int? GrnsDeleted,
		                        ref string Infobar)
		{
			GrnStatusType _GrnStat = GrnStat;
			GrnNumType _StartGrnNum = StartGrnNum;
			GrnNumType _EndGrnNum = EndGrnNum;
			VendNumType _StartVendNum = StartVendNum;
			VendNumType _EndVendNum = EndVendNum;
			IntType _GrnsDeleted = GrnsDeleted;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GrnDelUtilSp";
				
				appDB.AddCommandParameter(cmd, "GrnStat", _GrnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartGrnNum", _StartGrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGrnNum", _EndGrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendNum", _StartVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnsDeleted", _GrnsDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GrnsDeleted = _GrnsDeleted;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
