//PROJECT NAME: Data
//CLASS NAME: CoFBomPR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoFBomPR : ICoFBomPR
	{
		readonly IApplicationDB appDB;
		
		public CoFBomPR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TIncPrice,
			string Infobar) CoFBomPRSp(
			string PItem,
			string TFeatStr,
			string PCoNum,
			int? PCoLine,
			decimal? TIncPrice,
			string Infobar)
		{
			ItemType _PItem = PItem;
			FeatTemplateType _TFeatStr = TFeatStr;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CostPrcType _TIncPrice = TIncPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoFBomPRSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFeatStr", _TFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIncPrice", _TIncPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TIncPrice = _TIncPrice;
				Infobar = _Infobar;
				
				return (Severity, TIncPrice, Infobar);
			}
		}
	}
}
