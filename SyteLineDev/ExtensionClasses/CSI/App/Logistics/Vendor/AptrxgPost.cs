//PROJECT NAME: Logistics
//CLASS NAME: AptrxgPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AptrxgPost : IAptrxgPost
	{
		readonly IApplicationDB appDB;
		
		
		public AptrxgPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AptrxgPostSp(Guid? PRecidAptrx,
		int? PCheck1,
		decimal? PSalesTax1,
		int? PCheck2,
		decimal? PSalesTax2,
		string Infobar)
		{
			RowPointerType _PRecidAptrx = PRecidAptrx;
			ListYesNoType _PCheck1 = PCheck1;
			GenericDecimalType _PSalesTax1 = PSalesTax1;
			ListYesNoType _PCheck2 = PCheck2;
			GenericDecimalType _PSalesTax2 = PSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AptrxgPostSp";
				
				appDB.AddCommandParameter(cmd, "PRecidAptrx", _PRecidAptrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheck1", _PCheck1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheck2", _PCheck2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
