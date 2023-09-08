//PROJECT NAME: Data
//CLASS NAME: FeatStrBuildJobmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FeatStrBuildJobmatl : IFeatStrBuildJobmatl
	{
		readonly IApplicationDB appDB;
		
		public FeatStrBuildJobmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FeatStrBuildJobmatlSp(
			string FeatStr,
			string Item,
			string CoNum = null,
			int? CoLine = null,
			string Infobar = null,
			int? ExpandPhantom = 0,
			decimal? QtyMultiplier = 1M,
			string Site = null)
		{
			FeatStrType _FeatStr = FeatStr;
			ItemType _Item = Item;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ExpandPhantom = ExpandPhantom;
			QtyUnitType _QtyMultiplier = QtyMultiplier;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FeatStrBuildJobmatlSp";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpandPhantom", _ExpandPhantom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMultiplier", _QtyMultiplier, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
