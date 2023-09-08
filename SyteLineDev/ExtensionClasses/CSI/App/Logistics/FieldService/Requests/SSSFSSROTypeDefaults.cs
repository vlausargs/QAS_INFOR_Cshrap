//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTypeDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTypeDefaults
	{
		(int? ReturnCode, string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? InclDemand,
		string Infobar) SSSFSSROTypeDefaultsSp(string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? InclDemand,
		string Infobar);
	}
	
	public class SSSFSSROTypeDefaults : ISSSFSSROTypeDefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTypeDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? InclDemand,
		string Infobar) SSSFSSROTypeDefaultsSp(string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? InclDemand,
		string Infobar)
		{
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROBillTypeType _BillType = BillType;
			FSCgsRevLocType _CGSLabor = CGSLabor;
			FSCgsRevLocType _CGSMatl = CGSMatl;
			FSCgsRevLocType _CGSMisc = CGSMisc;
			ListYesNoType _AccumWIP = AccumWIP;
			ListYesNoType _InclDemand = InclDemand;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTypeDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSLabor", _CGSLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMatl", _CGSMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMisc", _CGSMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumWIP", _AccumWIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InclDemand", _InclDemand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProductCode = _ProductCode;
				Whse = _Whse;
				BillCode = _BillCode;
				BillType = _BillType;
				CGSLabor = _CGSLabor;
				CGSMatl = _CGSMatl;
				CGSMisc = _CGSMisc;
				AccumWIP = _AccumWIP;
				InclDemand = _InclDemand;
				Infobar = _Infobar;
				
				return (Severity, ProductCode, Whse, BillCode, BillType, CGSLabor, CGSMatl, CGSMisc, AccumWIP, InclDemand, Infobar);
			}
		}
	}
}
