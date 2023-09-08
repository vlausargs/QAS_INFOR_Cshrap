//PROJECT NAME: NonTrans
//CLASS NAME: ItemWhstk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.NonTrans
{
	public interface IItemWhstk
	{
		(int? ReturnCode, int? RecordProcessed, string Infobar) ItemWhstkSp(string PBegItem,
		                                                                    string PEndItem,
		                                                                    string PWhse,
		                                                                    string PLoc,
		                                                                    byte? PMrbFlag,
		                                                                    byte? PPermFlag,
		                                                                    int? RecordProcessed,
		                                                                    string Infobar);
	}
	
	public class ItemWhstk : IItemWhstk
	{
		readonly IApplicationDB appDB;
		
		public ItemWhstk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RecordProcessed, string Infobar) ItemWhstkSp(string PBegItem,
		                                                                           string PEndItem,
		                                                                           string PWhse,
		                                                                           string PLoc,
		                                                                           byte? PMrbFlag,
		                                                                           byte? PPermFlag,
		                                                                           int? RecordProcessed,
		                                                                           string Infobar)
		{
			ItemType _PBegItem = PBegItem;
			ItemType _PEndItem = PEndItem;
			WhseType _PWhse = PWhse;
			LocType _PLoc = PLoc;
			ListYesNoType _PMrbFlag = PMrbFlag;
			ListYesNoType _PPermFlag = PPermFlag;
			IntType _RecordProcessed = RecordProcessed;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemWhstkSp";
				
				appDB.AddCommandParameter(cmd, "PBegItem", _PBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndItem", _PEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMrbFlag", _PMrbFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPermFlag", _PPermFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordProcessed", _RecordProcessed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RecordProcessed = _RecordProcessed;
				Infobar = _Infobar;
				
				return (Severity, RecordProcessed, Infobar);
			}
		}
	}
}
