//PROJECT NAME: Production
//CLASS NAME: IRSQC_XRefTopic.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_XRefTopic
	{
		(int? ReturnCode, int? o_topic_num) RSQC_XRefTopicSp(string i_topic,
		int? i_priority,
		int? o_topic_num);
	}
}

