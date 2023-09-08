//PROJECT NAME: Material
//CLASS NAME: MRPFirmPlanOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MRPFirmPlanOrders : IMRPFirmPlanOrders
	{
		readonly IApplicationDB appDB;
		
		
		public MRPFirmPlanOrders(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MRPFirmPlanOrdersSp(Guid? SessionID,
		string RefType,
		string VendNum = null,
		string PoNum = null,
		string PoChange = null,
		int? BlanketQtyOver = null,
		string ReqNum = null,
		string SfcparmsWoPrefix = null,
		int? CopyBom = null,
		int? CopyIndentedBom = null,
		string SfcparmsPsPrefix = null,
		int? SingleOrder = null,
		string TrnNum = null,
		string FromSite = null,
		string FromWhse = null,
		string ToSite = null,
		string ToWhse = null,
		int? DeleteMpw = 0,
		string Infobar = null)
		{
			RowPointerType _SessionID = SessionID;
			MrpWbTabType _RefType = RefType;
			VendNumType _VendNum = VendNum;
			PoNumType _PoNum = PoNum;
			ListAlwaysSometimesNeverType _PoChange = PoChange;
			ListYesNoType _BlanketQtyOver = BlanketQtyOver;
			ReqNumType _ReqNum = ReqNum;
			JobPrefixType _SfcparmsWoPrefix = SfcparmsWoPrefix;
			ListYesNoType _CopyBom = CopyBom;
			ListYesNoType _CopyIndentedBom = CopyIndentedBom;
			PsPrefixType _SfcparmsPsPrefix = SfcparmsPsPrefix;
			ListYesNoType _SingleOrder = SingleOrder;
			TrnNumType _TrnNum = TrnNum;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			ListYesNoType _DeleteMpw = DeleteMpw;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MRPFirmPlanOrdersSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChange", _PoChange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQtyOver", _BlanketQtyOver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SfcparmsWoPrefix", _SfcparmsWoPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyBom", _CopyBom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyIndentedBom", _CopyIndentedBom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SfcparmsPsPrefix", _SfcparmsPsPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SingleOrder", _SingleOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteMpw", _DeleteMpw, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
