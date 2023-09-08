//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckQCItemh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckQCItemh : IRSQC_CheckQCItemh
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckQCItemh(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Status,
		string Infobar) RSQC_CheckQCItemhSp(string Item,
		string RefType,
		string Entity,
		int? TestSeq,
		int? Status,
		string Infobar)
		{
			ItemType _Item = Item;
			QCRefType _RefType = RefType;
			QCDocNumType _Entity = Entity;
			QCTestSeqType _TestSeq = TestSeq;
			ListYesNoType _Status = Status;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckQCItemhSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Entity", _Entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TestSeq", _TestSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Status = _Status;
				Infobar = _Infobar;
				
				return (Severity, Status, Infobar);
			}
		}
	}
}
