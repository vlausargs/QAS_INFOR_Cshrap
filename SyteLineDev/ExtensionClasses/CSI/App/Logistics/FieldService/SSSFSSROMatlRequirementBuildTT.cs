//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROMatlRequirementBuildTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROMatlRequirementBuildTT : ISSSFSSROMatlRequirementBuildTT
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROMatlRequirementBuildTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PTotalQtyOnHand,
			decimal? PTotalQtyRsvdco) SSSFSSROMatlRequirementBuildTTSP(
			string PCCurrentSiteGroup = null,
			string PCurrentSiteList = null,
			string PDefaultSite = null,
			string PItem = null,
			int? PShowShortages = 1,
			DateTime? PSROStartDate = null,
			string PRefNum = null,
			int? PRefLineSuf = null,
			int? PRefRelease = null,
			decimal? PTotalQtyOnHand = null,
			decimal? PTotalQtyRsvdco = null)
		{
			SiteType _PCCurrentSiteGroup = PCCurrentSiteGroup;
			SiteType _PCurrentSiteList = PCurrentSiteList;
			SiteType _PDefaultSite = PDefaultSite;
			ItemType _PItem = PItem;
			ListYesNoType _PShowShortages = PShowShortages;
			DateType _PSROStartDate = PSROStartDate;
			StringType _PRefNum = PRefNum;
			IntType _PRefLineSuf = PRefLineSuf;
			IntType _PRefRelease = PRefRelease;
			QtyTotlType _PTotalQtyOnHand = PTotalQtyOnHand;
			QtyTotlType _PTotalQtyRsvdco = PTotalQtyRsvdco;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROMatlRequirementBuildTTSP";
				
				appDB.AddCommandParameter(cmd, "PCCurrentSiteGroup", _PCCurrentSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrentSiteList", _PCurrentSiteList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDefaultSite", _PDefaultSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowShortages", _PShowShortages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROStartDate", _PSROStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotalQtyOnHand", _PTotalQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTotalQtyRsvdco", _PTotalQtyRsvdco, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTotalQtyOnHand = _PTotalQtyOnHand;
				PTotalQtyRsvdco = _PTotalQtyRsvdco;
				
				return (Severity, PTotalQtyOnHand, PTotalQtyRsvdco);
			}
		}
	}
}
