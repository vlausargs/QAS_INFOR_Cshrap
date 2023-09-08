//PROJECT NAME: Logistics
//CLASS NAME: FeatQtySave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class FeatQtySave : IFeatQtySave
	{
		readonly IApplicationDB appDB;
		
		
		public FeatQtySave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FeatQtySaveSp(string CoNum,
		int? CoLine,
		string Feature,
		string OptCode,
		decimal? MatlQtyConv,
		string UM,
		string Item,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			FeatureType _Feature = Feature;
			OptCodeType _OptCode = OptCode;
			QtyPerType _MatlQtyConv = MatlQtyConv;
			UMType _UM = UM;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FeatQtySaveSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Feature", _Feature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OptCode", _OptCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQtyConv", _MatlQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
