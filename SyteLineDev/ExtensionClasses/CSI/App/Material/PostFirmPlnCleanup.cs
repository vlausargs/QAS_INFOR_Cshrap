//PROJECT NAME: Material
//CLASS NAME: PostFirmPlnCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PostFirmPlnCleanup : IPostFirmPlnCleanup
	{
		readonly IApplicationDB appDB;
		
		
		public PostFirmPlnCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PostFirmPlnCleanupSp(string OldRefType,
		string OldRefNum,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? DeleteDepDemand = 0,
		string Infobar = null,
		int? OldRefLineSuf = null)
		{
			MrpOrderTypeType _OldRefType = OldRefType;
			MrpOrderType _OldRefNum = OldRefNum;
			MrpOrderTypeType _RefType = RefType;
			MrpOrderType _RefNum = RefNum;
			MrpOrderLineType _RefLineSuf = RefLineSuf;
			ListYesNoType _DeleteDepDemand = DeleteDepDemand;
			InfobarType _Infobar = Infobar;
			MrpOrderLineType _OldRefLineSuf = OldRefLineSuf;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostFirmPlnCleanupSp";
				
				appDB.AddCommandParameter(cmd, "OldRefType", _OldRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldRefNum", _OldRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteDepDemand", _DeleteDepDemand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldRefLineSuf", _OldRefLineSuf, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
