//PROJECT NAME: Admin
//CLASS NAME: IRpt_ServiceContactPrivacyCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_ServiceContactPrivacyCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Fs_Cust_ContactSelect(Guid? RptSessionID, string pSite, string CustNum, int? CustSeq);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ServiceContactPrivacySp(string AltExtGenSp, string CustNum, int? CustSeq, string pSite);
	}
}

