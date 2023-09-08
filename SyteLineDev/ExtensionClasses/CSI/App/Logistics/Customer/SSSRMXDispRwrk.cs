//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispRwrk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispRwrk : ISSSRMXDispRwrk
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispRwrk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRMXDispRwrkSp(
			Guid? DispRowPointer,
			string iSroCopyTransFrom,
			string iTemplateSroNum,
			int? iTemplateSROLine,
			string iSelectedOpers,
			string iBillMgr,
			string iSRODesc,
			string iLeadPartner,
			string iCompItem,
			decimal? iCompQtyOrd,
			int? RewSROCreatedAlready,
			string RewSroNum,
			int? RewSroLine,
			int? RewSroOper,
			string Infobar)
		{
			RowPointer _DispRowPointer = DispRowPointer;
			StringType _iSroCopyTransFrom = iSroCopyTransFrom;
			FSSRONumType _iTemplateSroNum = iTemplateSroNum;
			FSSROLineType _iTemplateSROLine = iTemplateSROLine;
			LongListType _iSelectedOpers = iSelectedOpers;
			FSPartnerType _iBillMgr = iBillMgr;
			DescriptionType _iSRODesc = iSRODesc;
			FSPartnerType _iLeadPartner = iLeadPartner;
			ItemType _iCompItem = iCompItem;
			QtyUnitType _iCompQtyOrd = iCompQtyOrd;
			FlagNyType _RewSROCreatedAlready = RewSROCreatedAlready;
			FSSRONumType _RewSroNum = RewSroNum;
			FSSROLineType _RewSroLine = RewSroLine;
			FSSROOperType _RewSroOper = RewSroOper;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispRwrkSp";
				
				appDB.AddCommandParameter(cmd, "DispRowPointer", _DispRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransFrom", _iSroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTemplateSROLine", _iTemplateSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSelectedOpers", _iSelectedOpers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillMgr", _iBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSRODesc", _iSRODesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLeadPartner", _iLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompItem", _iCompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCompQtyOrd", _iCompQtyOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSROCreatedAlready", _RewSROCreatedAlready, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroNum", _RewSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroLine", _RewSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RewSroOper", _RewSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
