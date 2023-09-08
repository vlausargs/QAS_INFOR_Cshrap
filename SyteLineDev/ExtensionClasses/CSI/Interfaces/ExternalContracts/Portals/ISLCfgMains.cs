using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLCfgMains
    {
        int CfgDeleteRefsSp(string pConfigId, byte? pJobFlag, string pJob, short? pSuffix, ref string Infobar);

        int BDCGetQueuedStatus(string sApplID, string sKey1, string sOrderType, string sKey2, string sConfigID, string sSessionID, string sSite, string sQueuePostProcess, ref string sReturnValue);

        int CfgClearRefsSp(string pConfigId, byte? pJobFlag, string pJob, short? pSuffix, ref string Infobar);

        int CfgCopyConfigSp(string pOldConfigID, string pNewCoNum, short? pNewCoLine, short? pNewCoRelease, string pNewJob, short? pNewSuffix, string pNewItem, string pNewConfigGid, string pConfigurator, ref string Infobar);

        int CfgIPNCheckSp(string pConfigId, string pCEP, ref byte? pIpn, ref string pNewItem, string CloneSite, ref string Infobar);

        void CfgMapConfigurationData(string sOrderNum, int sOrderLine, string sOrderType, string sTargetConfigId, string sDetailId, string sGlobalConfigServerId, string sGlobalConfigurator, string sGlobalParmSite, string sGlobalConfiguratorURL, ref string InfoBar, string sSessionId);

        int CfgSetConfigIdSp(string ConfigEntryPoint, string Key1, string Key2, string Key3, string ConfigId, ref string ConfigGid, byte? IsDocId);

        int GetCfgParmsSp(ref string ConfigServerId, ref string ConfigHeaderNameSpace, ref string Configurator, ref string ConfiguratorURL, ref string MetatdataInstance, ref string AuthenticationKey, string Site);

        int GetQueueConfigurationSp(string ConfigId, ref string QueuePostConfiguration, ref string QueuePostConfigurationMessage, ref string QueueRequestID, ref string QueueStatus, ref string QueueType);

        int ImportConfigurationToShipFromSite(string sInstanceName, string sApplID, string sApplIDShipSite, string sHeaderId, string sDetailId, ref string Infobar);

        int PortalCfgDoConfigSp(string pConfigId, string pCep, byte? pCreateJob, string pRunFrom, string pRunMode, byte? pUpdatePrice, ref byte? DoRefresh, ref string Infobar, ref byte? Warning, ref Guid? SessionID);

        int UpdateCfgStatusSp(string ConfigId, string StatusAttrValue, string MsgAttrValue, string QueueIDValue);
    }

}
