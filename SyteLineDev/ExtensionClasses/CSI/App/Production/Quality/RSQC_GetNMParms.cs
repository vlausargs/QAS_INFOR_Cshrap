//PROJECT NAME: Production
//CLASS NAME: RSQC_GetNMParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetNMParms : IRSQC_GetNMParms
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetNMParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? topic_tag,
		int? change_tag,
		int? creator_validation,
		int? closed_by,
		int? validate_change_type,
		string TopicEMail,
		string ChangeEMail,
		string TrrEMail,
		string CmrEMail,
		int? calc_aql,
		int? create_first_article_receivers,
		string Infobar) RSQC_GetNMParmsSp(int? topic_tag,
		int? change_tag,
		int? creator_validation,
		int? closed_by,
		int? validate_change_type,
		string TopicEMail,
		string ChangeEMail,
		string TrrEMail,
		string CmrEMail,
		int? calc_aql,
		int? create_first_article_receivers,
		string Infobar)
		{
			ListYesNoType _topic_tag = topic_tag;
			ListYesNoType _change_tag = change_tag;
			ByteType _creator_validation = creator_validation;
			ByteType _closed_by = closed_by;
			ListYesNoType _validate_change_type = validate_change_type;
			QCCharType _TopicEMail = TopicEMail;
			QCCharType _ChangeEMail = ChangeEMail;
			QCCharType _TrrEMail = TrrEMail;
			QCCharType _CmrEMail = CmrEMail;
			ListYesNoType _calc_aql = calc_aql;
			ListYesNoType _create_first_article_receivers = create_first_article_receivers;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetNMParmsSp";
				
				appDB.AddCommandParameter(cmd, "topic_tag", _topic_tag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "change_tag", _change_tag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "creator_validation", _creator_validation, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "closed_by", _closed_by, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "validate_change_type", _validate_change_type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TopicEMail", _TopicEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ChangeEMail", _ChangeEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrrEMail", _TrrEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CmrEMail", _CmrEMail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "calc_aql", _calc_aql, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "create_first_article_receivers", _create_first_article_receivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				topic_tag = _topic_tag;
				change_tag = _change_tag;
				creator_validation = _creator_validation;
				closed_by = _closed_by;
				validate_change_type = _validate_change_type;
				TopicEMail = _TopicEMail;
				ChangeEMail = _ChangeEMail;
				TrrEMail = _TrrEMail;
				CmrEMail = _CmrEMail;
				calc_aql = _calc_aql;
				create_first_article_receivers = _create_first_article_receivers;
				Infobar = _Infobar;
				
				return (Severity, topic_tag, change_tag, creator_validation, closed_by, validate_change_type, TopicEMail, ChangeEMail, TrrEMail, CmrEMail, calc_aql, create_first_article_receivers, Infobar);
			}
		}
	}
}
