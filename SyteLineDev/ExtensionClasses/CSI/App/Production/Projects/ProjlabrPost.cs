//PROJECT NAME: CSIProjects
//CLASS NAME: ProjlabrPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjlabrPost
	{
		(int? ReturnCode, string Infobar) ProjlabrPostSp(string FromProjNum,
		string ToProjNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromEmpNum,
		string ToEmpNum,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		Guid? PSessionID = null);
	}
	
	public class ProjlabrPost : IProjlabrPost
	{
		readonly IApplicationDB appDB;
		
		public ProjlabrPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjlabrPostSp(string FromProjNum,
		string ToProjNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromEmpNum,
		string ToEmpNum,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		Guid? PSessionID = null)
		{
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			GenericDateType _FromTransDate = FromTransDate;
			GenericDateType _ToTransDate = ToTransDate;
			HighLowCharType _FromEmpNum = FromEmpNum;
			HighLowCharType _ToEmpNum = ToEmpNum;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjlabrPostSp";
				
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
