//PROJECT NAME: Finance
//CLASS NAME: IChartAcctDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface IChartAcctDeleteCRUD
    {
        bool Ana_LedgerForExists(string pChartAcct);
        bool ApdrafttForExists(string pChartAcct);
        bool ApparmsForExists(string pChartAcct);
        bool AppmtdForExists(string pChartAcct);
        bool AptrxdForExists(string pChartAcct);
        bool AptrxForExists(string pChartAcct);
        bool AptrxpForExists(string pChartAcct);
        bool AptrxrForExists(string pChartAcct);
        bool AptxrdForExists(string pChartAcct);
        bool ArdrafttForExists(string pChartAcct);
        bool ArfinForExists(string pChartAcct);
        bool ArinvdForExists(string pChartAcct);
        bool ArinvForExists(string pChartAcct);
        bool ArparmsForExists(string pChartAcct);
        bool ArpmtdForExists(string pChartAcct);
        bool ArtranForExists(string pChartAcct);
        bool Bank_AddrForExists(string pChartAcct);
        bool Bank_HdrForExists(string pChartAcct);
        bool Chart_BpForExists(string pChartAcct);
        bool Chart_DForExists(string pChartAcct);
        bool CommdueForExists(string pChartAcct);
        bool CommtranForExists(string pChartAcct);
        bool CurracctForExists(string pChartAcct);
        bool CurrparmsForExists(string pChartAcct);
        bool DcjmForExists(string pChartAcct);
        bool DeptForExists(string pChartAcct);
        bool DiscountForExists(string pChartAcct);
        bool DistacctForExists(string pChartAcct);
        bool Edi_Inv_HdrForExists(string pChartAcct);
        bool Edi_Inv_ItemForExists(string pChartAcct);
        bool Edi_Inv_StaxForExists(string pChartAcct);
        bool EmployeeForExists(string pChartAcct);
        bool EndtypeForExists(string pChartAcct);
        bool FaclassForExists(string pChartAcct);
        bool FadistForExists(string pChartAcct);
        bool FaparmsForExists(string pChartAcct);
        bool IndcodeForExists(string pChartAcct);
        bool Inv_HdrForExists(string pChartAcct);
        bool Inv_ItemForExists(string pChartAcct);
        bool Inv_Item_SurchargeForExists(string pChartAcct);
        bool Inv_StaxForExists(string pChartAcct);
        bool ItemlifoForExists(string pChartAcct);
        bool ItemlocForExists(string pChartAcct);
        bool JobForExists(string pChartAcct);
        bool JournalForExists(string pChartAcct);
        bool LedgerForExists(string pChartAcct);
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        ICollectionLoadResponse Optional_Module1Select();
        bool Optional_ModuleForExists();
        string Parms1Load();
        bool ParmsForExists(string pChartAcct);
        bool PitemhForExists(string pChartAcct);
        bool PoblnhForExists(string pChartAcct);
        bool PoitemForExists(string pChartAcct);
        bool PoparmsForExists(string pChartAcct);
        bool Po_BlnForExists(string pChartAcct);
        bool PrbankForExists(string pChartAcct);
        bool PrdecdForExists(string pChartAcct);
        bool PreqitemForExists(string pChartAcct);
        bool ProdcodeForExists(string pChartAcct);
        bool ProdvarForExists(string pChartAcct);
        bool ProjparmForExists(string pChartAcct);
        bool Proj_WipForExists(string pChartAcct);
        bool PrparmsForExists(string pChartAcct);
        bool PrtaxtForExists(string pChartAcct);
        bool PrtrxdForExists(string pChartAcct);
        bool Reason1ForExists(string pChartAcct);
        bool ReasonForExists(string pChartAcct);
        bool RmaparmsForExists(string pChartAcct);
        bool SfcparmsForExists(string pChartAcct);
        bool SitenetForExists(string pChartAcct, string ParmsSite);
        bool TaxcodeForExists(string pChartAcct);
        string Tv_ALTGEN1Load();
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        bool Tv_ALTGENForExists();
        bool Vch_DistForExists(string pChartAcct);
        bool Vch_HdrForExists(string pChartAcct);
        bool Vch_ItemForExists(string pChartAcct);
        bool Vch_PrForExists(string pChartAcct);
        bool Vch_StaxForExists(string pChartAcct);
        bool VendcatForExists(string pChartAcct);
        bool VendorForExists(string pChartAcct);
        bool WcForExists(string pChartAcct);
        (int? ReturnCode, string Infobar) AltExtGen_ChartAcctDeleteSp(string AltExtGenSp, int? pNewRecord, string pChartAcct, string Infobar);
    }
}