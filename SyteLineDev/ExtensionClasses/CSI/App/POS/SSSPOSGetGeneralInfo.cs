//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetGeneralInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetGeneralInfo : ISSSPOSGetGeneralInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetGeneralInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			CustNumType _pCustNum = pCustNum;
			CustSeqType _pCustSeq = pCustSeq;
			WhseType _pCurWhse = pCurWhse;
			ShipCodeType _pshipcode = pshipcode;
			TermsCodeType _ptermscode = ptermscode;
			PriceCodeType _ppricecode = ppricecode;
			EndUserTypeType _pendusertype = pendusertype;
			SlsmanType _pslsman = pslsman;
			WhseType _pwhse = pwhse;
			ListYesNoType _pshipearly = pshipearly;
			ListYesNoType _pshippartial = pshippartial;
			ListYesNoType _pconsolidate = pconsolidate;
			ListYesNoType _psummarize = psummarize;
			InvFreqType _pinvfreq = pinvfreq;
			ListYesNoType _peinvoice = peinvoice;
			ListYesNoType _pApsPullUp = pApsPullUp;
			ContactType _pcontact = pcontact;
			PhoneType _pphone = pphone;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSGetGeneralInfoSp";
				
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustSeq", _pCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurWhse", _pCurWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pshipcode", _pshipcode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ptermscode", _ptermscode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ppricecode", _ppricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pendusertype", _pendusertype, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pslsman", _pslsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pwhse", _pwhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pshipearly", _pshipearly, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pshippartial", _pshippartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pconsolidate", _pconsolidate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "psummarize", _psummarize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pinvfreq", _pinvfreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "peinvoice", _peinvoice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pApsPullUp", _pApsPullUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pcontact", _pcontact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pphone", _pphone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCurWhse = _pCurWhse;
				pshipcode = _pshipcode;
				ptermscode = _ptermscode;
				ppricecode = _ppricecode;
				pendusertype = _pendusertype;
				pslsman = _pslsman;
				pwhse = _pwhse;
				pshipearly = _pshipearly;
				pshippartial = _pshippartial;
				pconsolidate = _pconsolidate;
				psummarize = _psummarize;
				pinvfreq = _pinvfreq;
				peinvoice = _peinvoice;
				pApsPullUp = _pApsPullUp;
				pcontact = _pcontact;
				pphone = _pphone;
				Infobar = _Infobar;
				
				return (Severity, pCurWhse, pshipcode, ptermscode, ppricecode, pendusertype, pslsman, pwhse, pshipearly, pshippartial, pconsolidate, psummarize, pinvfreq, peinvoice, pApsPullUp, pcontact, pphone, Infobar);
			}
		}
	}
}
