//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCCRcvrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCCRcvrs")]
    public class RS_QCCRcvrs : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateCmrSp(int? i_crcvr,
		string i_note,
		ref string o_cmr,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateCmrExt = new RSQC_CreateCmrFactory().Create(appDb);
				
				var result = iRSQC_CreateCmrExt.RSQC_CreateCmrSp(i_crcvr,
				i_note,
				o_cmr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_cmr = result.o_cmr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetNMParmsSp(ref int? topic_tag,
		ref int? change_tag,
		ref int? creator_validation,
		ref int? closed_by,
		ref int? validate_change_type,
		ref string TopicEMail,
		ref string ChangeEMail,
		ref string TrrEMail,
		ref string CmrEMail,
		ref int? calc_aql,
		ref int? create_first_article_receivers,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetNMParmsExt = new RSQC_GetNMParmsFactory().Create(appDb);
				
				var result = iRSQC_GetNMParmsExt.RSQC_GetNMParmsSp(topic_tag,
				change_tag,
				creator_validation,
				closed_by,
				validate_change_type,
				TopicEMail,
				ChangeEMail,
				TrrEMail,
				CmrEMail,
				calc_aql,
				create_first_article_receivers,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				topic_tag = result.topic_tag;
				change_tag = result.change_tag;
				creator_validation = result.creator_validation;
				closed_by = result.closed_by;
				validate_change_type = result.validate_change_type;
				TopicEMail = result.TopicEMail;
				ChangeEMail = result.ChangeEMail;
				TrrEMail = result.TrrEMail;
				CmrEMail = result.CmrEMail;
				calc_aql = result.calc_aql;
				create_first_article_receivers = result.create_first_article_receivers;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetUserSp(ref string o_user,
            ref string Infobar)
        {
            var iRSQC_GetUserExt = new RSQC_GetUserFactory().Create(this, true);

            var result = iRSQC_GetUserExt.RSQC_GetUserSp(o_user,
                Infobar);

            o_user = result.o_user;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
