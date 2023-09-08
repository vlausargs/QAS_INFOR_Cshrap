//PROJECT NAME: Production
//CLASS NAME: DeleteJobTransactionItemPieces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class DeleteJobTransactionItemPieces : IDeleteJobTransactionItemPieces
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteJobTransactionItemPieces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteJobTransactionItemPiecesSp(decimal? PTransNum,
		string PItem = null,
		string Infobar = null)
		{
			HugeTransNumType _PTransNum = PTransNum;
			ItemType _PItem = PItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteJobTransactionItemPiecesSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
