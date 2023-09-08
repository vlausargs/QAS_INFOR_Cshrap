//PROJECT NAME: Production
//CLASS NAME: SeqProjBolVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class SeqProjBolVal : ISeqProjBolVal
	{
		readonly IApplicationDB appDB;
		
		
		public SeqProjBolVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Description,
		decimal? Qty,
		string UM,
		decimal? Weight,
		string Infobar) SeqProjBolValSp(string ProjNum,
		string BolNum,
		int? TaskNum,
		int? Seq,
		string Item,
		string Description,
		decimal? Qty,
		string UM,
		decimal? Weight,
		string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			BolNumType _BolNum = BolNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			QtyUnitNoNegType _Qty = Qty;
			UMType _UM = UM;
			WeightType _Weight = Weight;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SeqProjBolValSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BolNum", _BolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Description = _Description;
				Qty = _Qty;
				UM = _UM;
				Weight = _Weight;
				Infobar = _Infobar;
				
				return (Severity, Item, Description, Qty, UM, Weight, Infobar);
			}
		}
	}
}
