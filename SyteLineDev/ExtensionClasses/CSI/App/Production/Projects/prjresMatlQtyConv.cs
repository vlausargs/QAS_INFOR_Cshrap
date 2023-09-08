//PROJECT NAME: Production
//CLASS NAME: prjresMatlQtyConv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class prjresMatlQtyConv : IprjresMatlQtyConv
	{
		readonly IApplicationDB appDB;
		
		
		public prjresMatlQtyConv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) prjresMatlQtyConvSp(decimal? NewMatlQty,
		string PItem,
		string Infobar)
		{
			QtyPerType _NewMatlQty = NewMatlQty;
			ItemType _PItem = PItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresMatlQtyConvSp";
				
				appDB.AddCommandParameter(cmd, "NewMatlQty", _NewMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
