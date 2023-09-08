//PROJECT NAME: Material
//CLASS NAME: WhseQtyList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class WhseQtyList : IWhseQtyList
	{
		readonly IApplicationDB appDB;
		
		
		public WhseQtyList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PTotalOnHand,
		string PWhseOnHand) WhseQtyListSp(string PWhse = null,
		string PIitem = null,
		decimal? PTotalOnHand = null,
		string PWhseOnHand = null)
		{
			WhseType _PWhse = PWhse;
			ItemType _PIitem = PIitem;
			QtyTotlType _PTotalOnHand = PTotalOnHand;
			StringType _PWhseOnHand = PWhseOnHand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WhseQtyListSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIitem", _PIitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotalOnHand", _PTotalOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWhseOnHand", _PWhseOnHand, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTotalOnHand = _PTotalOnHand;
				PWhseOnHand = _PWhseOnHand;
				
				return (Severity, PTotalOnHand, PWhseOnHand);
			}
		}
	}
}
