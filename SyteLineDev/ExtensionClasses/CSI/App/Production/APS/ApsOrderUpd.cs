//PROJECT NAME: Production
//CLASS NAME: ApsOrderUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsOrderUpd : IApsOrderUpd
	{
		readonly IApplicationDB appDB;
		
		
		public ApsOrderUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsOrderUpdSp(string OrdID,
		string Descr,
		string Cust,
		int? OrdTyp,
		string MatlID,
		decimal? OrdSiz,
		DateTime? ArivDate,
		DateTime? DueDate,
		DateTime? RequDate,
		int? Cat,
		string RefOrdID,
		string Whse,
		string PlanOnly,
		string SchedOnly,
		string AutoPlan,
		int? OrdFlags,
		string PartID,
		DateTime? RelDate,
		string ProcPlan,
		int? DerPassMfg,
		int? DerPassPur,
		int? DerDNInv,
		int? DerDNSup,
		int? DerRep,
		int? DerCoPr,
		int? DerDNAScrap,
		int? DerDNAMin,
		int? DerPullUp,
		int? DerRestr,
		int? DerStop,
		int? DerCross,
		int? DerFixSup,
		int? DerFixDem,
		Guid? RowP,
		int? AltNo,
		string OrderTable)
		{
			ApsOrderType _OrdID = OrdID;
			ApsDescriptType _Descr = Descr;
			ApsCustomerType _Cust = Cust;
			ApsOrdTypeType _OrdTyp = OrdTyp;
			ApsMaterialType _MatlID = MatlID;
			ApsFloatType _OrdSiz = OrdSiz;
			DateTimeType _ArivDate = ArivDate;
			DateTimeType _DueDate = DueDate;
			DateTimeType _RequDate = RequDate;
			ApsCategoryType _Cat = Cat;
			ApsOrderType _RefOrdID = RefOrdID;
			ApsWhseType _Whse = Whse;
			ApsFlagType _PlanOnly = PlanOnly;
			ApsFlagType _SchedOnly = SchedOnly;
			ApsFlagType _AutoPlan = AutoPlan;
			ApsBitFlagsType _OrdFlags = OrdFlags;
			ApsPartType _PartID = PartID;
			DateTimeType _RelDate = RelDate;
			ApsProcplanType _ProcPlan = ProcPlan;
			ListYesNoType _DerPassMfg = DerPassMfg;
			ListYesNoType _DerPassPur = DerPassPur;
			ListYesNoType _DerDNInv = DerDNInv;
			ListYesNoType _DerDNSup = DerDNSup;
			ListYesNoType _DerRep = DerRep;
			ListYesNoType _DerCoPr = DerCoPr;
			ListYesNoType _DerDNAScrap = DerDNAScrap;
			ListYesNoType _DerDNAMin = DerDNAMin;
			ListYesNoType _DerPullUp = DerPullUp;
			ListYesNoType _DerRestr = DerRestr;
			ListYesNoType _DerStop = DerStop;
			ListYesNoType _DerCross = DerCross;
			ListYesNoType _DerFixSup = DerFixSup;
			ListYesNoType _DerFixDem = DerFixDem;
			RowPointerType _RowP = RowP;
			ApsAltNoType _AltNo = AltNo;
			TableNameType _OrderTable = OrderTable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsOrderUpdSp";
				
				appDB.AddCommandParameter(cmd, "OrdID", _OrdID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cust", _Cust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdTyp", _OrdTyp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlID", _MatlID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdSiz", _OrdSiz, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArivDate", _ArivDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequDate", _RequDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cat", _Cat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefOrdID", _RefOrdID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanOnly", _PlanOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedOnly", _SchedOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoPlan", _AutoPlan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdFlags", _OrdFlags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartID", _PartID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RelDate", _RelDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcPlan", _ProcPlan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPassMfg", _DerPassMfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPassPur", _DerPassPur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDNInv", _DerDNInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDNSup", _DerDNSup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerRep", _DerRep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerCoPr", _DerCoPr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDNAScrap", _DerDNAScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDNAMin", _DerDNAMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPullUp", _DerPullUp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerRestr", _DerRestr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerStop", _DerStop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerCross", _DerCross, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerFixSup", _DerFixSup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerFixDem", _DerFixDem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowP", _RowP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderTable", _OrderTable, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
