//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetNMParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetNMParms
	{
		(int? ReturnCode, int? topic_tag,
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
		string Infobar);
	}
}

