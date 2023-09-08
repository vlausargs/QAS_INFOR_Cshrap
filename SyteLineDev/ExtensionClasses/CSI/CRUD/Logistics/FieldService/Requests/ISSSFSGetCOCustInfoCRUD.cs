//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetCOCustInfoCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSGetCOCustInfoCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string oCustNum, int? oCustSeq, int? rowCount) COLoad(string iCoNum, string oCustNum, int? oCustSeq);
		(int? ReturnCode, string oCustNum,int? oCustSeq) AltExtGen_SSSFSGetCOCustInfoSp(string AltExtGenSp, string iCoNum, string oCustNum, int? oCustSeq);
	}
}

