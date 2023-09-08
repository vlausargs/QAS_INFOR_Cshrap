//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionBySite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetInteractionBySite
	{
		(int? ReturnCode, string SiteRef, string Description, string Topic, string CustNum, int? CustSeq, string CustName, string Status, DateTime? InteractionDate, DateTime? FollowDate, string Slsman, string Infobar) GetInteractionBySiteSp(string InteractionType,
		decimal? InteractionId,
		string SiteRef,
		string Description,
		string Topic,
		string CustNum,
		int? CustSeq,
		string CustName,
		string Status,
		DateTime? InteractionDate,
		DateTime? FollowDate,
		string Slsman,
		string Infobar = null);
	}
	
	public class GetInteractionBySite : IGetInteractionBySite
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionBySite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SiteRef, string Description, string Topic, string CustNum, int? CustSeq, string CustName, string Status, DateTime? InteractionDate, DateTime? FollowDate, string Slsman, string Infobar) GetInteractionBySiteSp(string InteractionType,
		decimal? InteractionId,
		string SiteRef,
		string Description,
		string Topic,
		string CustNum,
		int? CustSeq,
		string CustName,
		string Status,
		DateTime? InteractionDate,
		DateTime? FollowDate,
		string Slsman,
		string Infobar = null)
		{
			InteractionTypeType _InteractionType = InteractionType;
			InteractionIdType _InteractionId = InteractionId;
			SiteType _SiteRef = SiteRef;
			DescriptionType _Description = Description;
			CommLogTopicType _Topic = Topic;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			NameType _CustName = CustName;
			CommLogStatusType _Status = Status;
			DateType _InteractionDate = InteractionDate;
			DateType _FollowDate = FollowDate;
			SlsmanType _Slsman = Slsman;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInteractionBySiteSp";
				
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionId", _InteractionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InteractionDate", _InteractionDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FollowDate", _FollowDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SiteRef = _SiteRef;
				Description = _Description;
				Topic = _Topic;
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				CustName = _CustName;
				Status = _Status;
				InteractionDate = _InteractionDate;
				FollowDate = _FollowDate;
				Slsman = _Slsman;
				Infobar = _Infobar;
				
				return (Severity, SiteRef, Description, Topic, CustNum, CustSeq, CustName, Status, InteractionDate, FollowDate, Slsman, Infobar);
			}
		}
	}
}
