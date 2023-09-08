//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSRODefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSRODefaults
	{
		int SSSFSSRODefaultsSp(ref string SROType,
		                       ref string SROTypeDesc,
		                       ref string ProductCode,
		                       ref string ProductCodeDesc,
		                       ref string Whse,
		                       ref string WhseName,
		                       ref string BillCode,
		                       ref string BillType,
		                       ref string CGSLabor,
		                       ref string CGSMatl,
		                       ref string CGSMisc,
		                       ref decimal? Disc,
		                       ref byte? AccumWIP,
		                       ref byte? InclDemand,
		                       ref byte? AllowPartial,
		                       ref byte? PlanTransReq,
		                       ref byte? UsePlanPricing,
		                       ref byte? UseEndUserTypes,
		                       ref byte? UseConsumer,
		                       ref byte? AutoCloseSRO,
		                       ref string PriorCode,
		                       ref string StatCode,
		                       ref string Infobar);
	}
	
	public class SSSFSSRODefaults : ISSSFSSRODefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSRODefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSRODefaultsSp(ref string SROType,
		                              ref string SROTypeDesc,
		                              ref string ProductCode,
		                              ref string ProductCodeDesc,
		                              ref string Whse,
		                              ref string WhseName,
		                              ref string BillCode,
		                              ref string BillType,
		                              ref string CGSLabor,
		                              ref string CGSMatl,
		                              ref string CGSMisc,
		                              ref decimal? Disc,
		                              ref byte? AccumWIP,
		                              ref byte? InclDemand,
		                              ref byte? AllowPartial,
		                              ref byte? PlanTransReq,
		                              ref byte? UsePlanPricing,
		                              ref byte? UseEndUserTypes,
		                              ref byte? UseConsumer,
		                              ref byte? AutoCloseSRO,
		                              ref string PriorCode,
		                              ref string StatCode,
		                              ref string Infobar)
		{
			FSSROTypeType _SROType = SROType;
			DescriptionType _SROTypeDesc = SROTypeDesc;
			ProductCodeType _ProductCode = ProductCode;
			DescriptionType _ProductCodeDesc = ProductCodeDesc;
			WhseType _Whse = Whse;
			NameType _WhseName = WhseName;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROBillTypeType _BillType = BillType;
			FSCgsRevLocType _CGSLabor = CGSLabor;
			FSCgsRevLocType _CGSMatl = CGSMatl;
			FSCgsRevLocType _CGSMisc = CGSMisc;
			OrderDiscType _Disc = Disc;
			ListYesNoType _AccumWIP = AccumWIP;
			ListYesNoType _InclDemand = InclDemand;
			ListYesNoType _AllowPartial = AllowPartial;
			ListYesNoType _PlanTransReq = PlanTransReq;
			ListYesNoType _UsePlanPricing = UsePlanPricing;
			ListYesNoType _UseEndUserTypes = UseEndUserTypes;
			ListYesNoType _UseConsumer = UseConsumer;
			ListYesNoType _AutoCloseSRO = AutoCloseSRO;
			FSIncPriorCodeType _PriorCode = PriorCode;
			FSStatCodeType _StatCode = StatCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSRODefaultsSp";
				
				appDB.AddCommandParameter(cmd, "SROType", _SROType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROTypeDesc", _SROTypeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCodeDesc", _ProductCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseName", _WhseName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSLabor", _CGSLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMatl", _CGSMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMisc", _CGSMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumWIP", _AccumWIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InclDemand", _InclDemand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowPartial", _AllowPartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanTransReq", _PlanTransReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsePlanPricing", _UsePlanPricing, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseEndUserTypes", _UseEndUserTypes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseConsumer", _UseConsumer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoCloseSRO", _AutoCloseSRO, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROType = _SROType;
				SROTypeDesc = _SROTypeDesc;
				ProductCode = _ProductCode;
				ProductCodeDesc = _ProductCodeDesc;
				Whse = _Whse;
				WhseName = _WhseName;
				BillCode = _BillCode;
				BillType = _BillType;
				CGSLabor = _CGSLabor;
				CGSMatl = _CGSMatl;
				CGSMisc = _CGSMisc;
				Disc = _Disc;
				AccumWIP = _AccumWIP;
				InclDemand = _InclDemand;
				AllowPartial = _AllowPartial;
				PlanTransReq = _PlanTransReq;
				UsePlanPricing = _UsePlanPricing;
				UseEndUserTypes = _UseEndUserTypes;
				UseConsumer = _UseConsumer;
				AutoCloseSRO = _AutoCloseSRO;
				PriorCode = _PriorCode;
				StatCode = _StatCode;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
