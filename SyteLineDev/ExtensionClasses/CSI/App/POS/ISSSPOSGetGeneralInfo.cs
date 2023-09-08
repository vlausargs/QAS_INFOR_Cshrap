//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetGeneralInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetGeneralInfo
	{
		(int? ReturnCode,
			string pCurWhse,
			string pshipcode,
			string ptermscode,
			string ppricecode,
			string pendusertype,
			string pslsman,
			string pwhse,
			int? pshipearly,
			int? pshippartial,
			int? pconsolidate,
			int? psummarize,
			string pinvfreq,
			int? peinvoice,
			int? pApsPullUp,
			string pcontact,
			string pphone,
			string Infobar) SSSPOSGetGeneralInfoSp(
			string pCustNum,
			int? pCustSeq,
			string pCurWhse,
			string pshipcode,
			string ptermscode,
			string ppricecode,
			string pendusertype,
			string pslsman,
			string pwhse,
			int? pshipearly,
			int? pshippartial,
			int? pconsolidate,
			int? psummarize,
			string pinvfreq,
			int? peinvoice,
			int? pApsPullUp,
			string pcontact,
			string pphone,
			string Infobar);
	}
}

