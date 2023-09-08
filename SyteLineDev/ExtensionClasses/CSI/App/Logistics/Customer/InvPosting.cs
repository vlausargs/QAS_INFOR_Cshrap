//PROJECT NAME: Logistics
//CLASS NAME: InvPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPosting : IInvPosting
	{
		readonly IApplicationDB appDB;
		
		
		public InvPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar) InvPostingSp(Guid? PSessionID,
		string PCustNum,
		string PInvNum,
		int? PInvSeq,
		Guid? PJHeaderRowPointer,
		int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar,
		string ToSite = null,
		string PostSite = null)
		{
			RowPointerType _PSessionID = PSessionID;
			CustNumType _PCustNum = PCustNum;
			InvNumType _PInvNum = PInvNum;
			ArInvSeqType _PInvSeq = PInvSeq;
			RowPointerType _PJHeaderRowPointer = PJHeaderRowPointer;
			ListYesNoType _PostExtFin = PostExtFin;
			OperationCounterType _ExtFinOperationCounter = ExtFinOperationCounter;
			InfobarType _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			SiteType _PostSite = PostSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJHeaderRowPointer", _PJHeaderRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostExtFin", _PostExtFin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtFinOperationCounter", _ExtFinOperationCounter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostSite", _PostSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostExtFin = _PostExtFin;
				ExtFinOperationCounter = _ExtFinOperationCounter;
				Infobar = _Infobar;
				
				return (Severity, PostExtFin, ExtFinOperationCounter, Infobar);
			}
		}
	}
}
