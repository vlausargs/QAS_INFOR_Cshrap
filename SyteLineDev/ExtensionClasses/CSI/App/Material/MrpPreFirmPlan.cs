//PROJECT NAME: Material
//CLASS NAME: MrpPreFirmPlan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpPreFirmPlan : IMrpPreFirmPlan
	{
		readonly IApplicationDB appDB;
		
		public MrpPreFirmPlan(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? DueDate,
			string RefTab,
			string Source,
			string PlanCode,
			string Buyer,
			DateTime? ReleaseDate,
			int? Found,
			string Infobar) MrpPreFirmPlanSp(
			string Item,
			decimal? ReqdQty,
			DateTime? DueDate,
			string RefTab,
			string Source,
			string PlanCode,
			string Buyer,
			DateTime? ReleaseDate,
			int? Found,
			string Infobar,
			string ItemVend = null,
			string FromSite = null,
			string FromWhse = null,
			string ApsParmApsmode = null,
			decimal? HrsPerDay = null,
			string parms_Site = null,
			int? mrp_parm_PreqMrp = null,
			int? UsePln = 1,
			string ThingsToProcess = "I")
		{
			ItemType _Item = Item;
			QtyUnitType _ReqdQty = ReqdQty;
			DateType _DueDate = DueDate;
			JobTypeType _RefTab = RefTab;
			PMTCodeType _Source = Source;
			UserCodeType _PlanCode = PlanCode;
			UsernameType _Buyer = Buyer;
			DateType _ReleaseDate = ReleaseDate;
			ListYesNoType _Found = Found;
			InfobarType _Infobar = Infobar;
			VendNumType _ItemVend = ItemVend;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			SiteType _parms_Site = parms_Site;
			ListYesNoType _mrp_parm_PreqMrp = mrp_parm_PreqMrp;
			ListYesNoType _UsePln = UsePln;
			StringType _ThingsToProcess = ThingsToProcess;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpPreFirmPlanSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefTab", _RefTab, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Found", _Found, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemVend", _ItemVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "parms_Site", _parms_Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "mrp_parm_PreqMrp", _mrp_parm_PreqMrp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsePln", _UsePln, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThingsToProcess", _ThingsToProcess, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				RefTab = _RefTab;
				Source = _Source;
				PlanCode = _PlanCode;
				Buyer = _Buyer;
				ReleaseDate = _ReleaseDate;
				Found = _Found;
				Infobar = _Infobar;
				
				return (Severity, DueDate, RefTab, Source, PlanCode, Buyer, ReleaseDate, Found, Infobar);
			}
		}
	}
}
