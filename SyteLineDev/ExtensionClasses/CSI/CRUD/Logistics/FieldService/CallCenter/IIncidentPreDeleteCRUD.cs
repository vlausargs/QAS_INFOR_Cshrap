//PROJECT NAME: Logistics
//CLASS NAME: IIncidentPreDeleteCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface IIncidentPreDeleteCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string SroNum, int? rowCount) LoadFs_Sro(string IncNum, string SroNum);
		(string Site, int? rowCount) LoadParms(string Site);
		(int? ReturnCode, string Infobar) AltExtGen_IncidentPreDeleteSp(string AltExtGenSp, string IncNum, string Infobar);
	}
}

