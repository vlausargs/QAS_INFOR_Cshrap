//PROJECT NAME: Admin
//CLASS NAME: ICheckJourlockStatCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICheckJourlockStatCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(Guid? JourHdrRowPointer, int? JournalLocked, decimal? UserID, int? rowCount) Jour_HdrLoad(string Id, int? JournalLocked, Guid? JourHdrRowPointer, decimal? UserID);
		(string UserName, int? rowCount) UsernamesLoad(decimal? UserID, string UserName);
		(int? ReturnCode, string Infobar) AltExtGen_CheckJourlockStatSp(string AltExtGenSp, string Id, string Infobar);
	}
}

