//PROJECT NAME: Finance
//CLASS NAME: ICHSGetDigitsOfMainAcctCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetDigitsOfMainAcctCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? DigitsOfMainAcct, int? rowCount) CN_SysprmLoad(int? DigitsOfMainAcct);
		(int? ReturnCode, int? DigitsOfMainAcct) AltExtGen_CHSGetDigitsOfMainAcctSp(string AltExtGenSp, int? DigitsOfMainAcct);
	}
}

