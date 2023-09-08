//PROJECT NAME: Finance
//CLASS NAME: FaPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FaPost : IFaPost
	{
		readonly IApplicationDB appDB;
		
		
		public FaPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DTot,
		int? XErrorCnt,
		string Infobar) FaPostSp(Guid? CurrFadistRowPointer,
		int? IsLastFadistFaNum,
		decimal? DTot,
		int? XErrorCnt,
		string Infobar)
		{
			RowPointerType _CurrFadistRowPointer = CurrFadistRowPointer;
			ListYesNoType _IsLastFadistFaNum = IsLastFadistFaNum;
			GenericDecimalType _DTot = DTot;
			GenericNoType _XErrorCnt = XErrorCnt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FaPostSp";
				
				appDB.AddCommandParameter(cmd, "CurrFadistRowPointer", _CurrFadistRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsLastFadistFaNum", _IsLastFadistFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DTot", _DTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "XErrorCnt", _XErrorCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DTot = _DTot;
				XErrorCnt = _XErrorCnt;
				Infobar = _Infobar;
				
				return (Severity, DTot, XErrorCnt, Infobar);
			}
		}
	}
}
