Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.DataAccess
Imports Mongoose.Core.Common
Imports System.Data.SqlClient

Imports CSI.Data.SQL.UDDT
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports Mongoose.IDO.Protocol
Imports CSI.Data.RecordSets

<IDOExtensionClass("SLInvparms")>
Public Class SLInvparms
    Inherits ExtensionClassBase

    Private ReadOnly ParmsTable As String = "invparms"


    Public Function GetSystemParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer
        Dim dr As IDataReader = Nothing
        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using cmd As IDbCommand = appDB.CreateCommand()
                cmd.CommandText = String.Format("SELECT [{0}] FROM [" & ParmsTable & "]", strParmName)
                cmd.CommandType = CommandType.Text

                Try
                    dr = cmd.ExecuteReader()
                Catch ex As Exception
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    Throw New MGException(ex.Message)
                End Try

                Using reader As New MGDataReader(dr)
                    If reader.Read() Then
                        strParmValue = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(0))
                    Else
                        If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                            dr.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NotOneExists", "@" & ParmsTable))
                    End If
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                End Using
            End Using
        End Using
        Return 0
    End Function


    Public Function GetAllSystemParmPreDisplay(ByRef strLocNegFlgVal As String, ByRef strLocEcnJobVal As String, ByRef _
    strLocBflLocVal As String, ByRef strLocDefWhsVal As String, ByVal strLocNegFlgName As String, ByVal strLocEcnJobName As _
    String, ByVal strLocBflLocName As String, ByVal strLocDefWhsName As String) As Integer


        Dim dr As IDataReader = Nothing

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using cmd As IDbCommand = appDB.CreateCommand()
                cmd.CommandText = String.Format("SELECT {0},{1},{2},{3} FROM " & ParmsTable & "",
                                                          strLocNegFlgName, strLocEcnJobName, strLocBflLocName, strLocDefWhsName)
                cmd.CommandType = CommandType.Text

                Try
                    dr = cmd.ExecuteReader()
                Catch ex As Exception
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    Throw New MGException(ex.Message)
                End Try


                Using reader As New MGDataReader(dr)
                    If reader.Read() Then
                        strLocNegFlgVal = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(0))
                        strLocEcnJobVal = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(1))
                        strLocBflLocVal = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(2))
                        strLocDefWhsVal = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(3))
                    Else
                        If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                            dr.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NotOneExists", "@" & ParmsTable))
                    End If
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                End Using
            End Using
        End Using
        Return 0
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetInvParmsSp(ByRef LocalEcnJob As String, ByRef LocalBflushLoc As String, ByRef LocalNegFlag As Byte?, ByRef LocalDefWhse As String, ByRef LocalEcnStd As String, ByRef LocalPrintBarcodes As Byte?, ByRef LocalPackLoc As String, ByRef LocalShipLoc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetInvParmsExt As IGetInvParms = New GetInvParmsFactory().Create(appDb)

            Dim oLocalEcnJob As EcnModeType = LocalEcnJob
            Dim oLocalBflushLoc As LocType = LocalBflushLoc
            Dim oLocalNegFlag As ListYesNoType = LocalNegFlag
            Dim oLocalDefWhse As WhseType = LocalDefWhse
            Dim oLocalEcnStd As EcnModeType = LocalEcnStd
            Dim oLocalPrintBarcodes As ListYesNoType = LocalPrintBarcodes
            Dim oLocalPackLoc As LocType = LocalPackLoc
            Dim oLocalShipLoc As LocType = LocalShipLoc

            Dim Severity As Integer = iGetInvParmsExt.GetInvParmsSp(oLocalEcnJob, oLocalBflushLoc, oLocalNegFlag, oLocalDefWhse, oLocalEcnStd, oLocalPrintBarcodes, oLocalPackLoc, oLocalShipLoc)

            LocalEcnJob = oLocalEcnJob
            LocalBflushLoc = oLocalBflushLoc
            LocalNegFlag = oLocalNegFlag
            LocalDefWhse = oLocalDefWhse
            LocalEcnStd = oLocalEcnStd
            LocalPrintBarcodes = oLocalPrintBarcodes
            LocalPackLoc = oLocalPackLoc
            LocalShipLoc = oLocalShipLoc

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvParmsBflushLocValidSp(ByVal PInvParmsBflushLoc As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInvParmsBflushLocValidExt As IInvParmsBflushLocValid = New InvParmsBflushLocValidFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iInvParmsBflushLocValidExt.InvParmsBflushLocValidSp(PInvParmsBflushLoc, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvparmsDefLocValidSp(ByVal Loc As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInvparmsDefLocValidExt As IInvparmsDefLocValid = New InvparmsDefLocValidFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iInvparmsDefLocValidExt.InvparmsDefLocValidSp(Loc, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InvParmsDefWhseValidSp(ByVal PInvParmsDefWhse As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iInvParmsDefWhseValidExt As IInvParmsDefWhseValid = New InvParmsDefWhseValidFactory().Create(appDb)

            Dim oInfobar As Infobar = Infobar

            Dim Severity As Integer = iInvParmsDefWhseValidExt.InvParmsDefWhseValidSp(PInvParmsDefWhse, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function VerifyUniqueLotSp(ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iVerifyUniqueLotExt As IVerifyUniqueLot = New VerifyUniqueLotFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iVerifyUniqueLotExt.VerifyUniqueLotSp(oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckTaxFreeMatlItemSp(
<[Optional]> ByVal Item As String, ByVal CallFrom As String, ByRef DisableEnable As Integer?,
<[Optional]> ByVal PSite As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iCheckTaxFreeMatlItemExt As ICheckTaxFreeMatlItem = New CheckTaxFreeMatlItemFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DisableEnable As Integer?) = iCheckTaxFreeMatlItemExt.CheckTaxFreeMatlItemSp(Item, CallFrom, DisableEnable, PSite)
            Dim Severity As Integer = result.ReturnCode.Value
            DisableEnable = result.DisableEnable
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCostItemAtWhseSP(ByRef CostItemAtWhse As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetCostItemAtWhseExt As IGetCostItemAtWhse = New GetCostItemAtWhseFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CostItemAtWhse As Integer?) = iGetCostItemAtWhseExt.GetCostItemAtWhseSP(CostItemAtWhse)
            Dim Severity As Integer = result.ReturnCode.Value
            CostItemAtWhse = result.CostItemAtWhse
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function GetRuleSetListSp(ByVal RSList As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetRuleSetListExt As IGetRuleSetList = New GetRuleSetListFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iGetRuleSetListExt.GetRuleSetListSp(RSList)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function MrpParmChkLowSetSp(ByVal ChkLow As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iMrpParmChkLowSetExt As IMrpParmChkLowSet = New MrpParmChkLowSetFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iMrpParmChkLowSetExt.MrpParmChkLowSetSp(ChkLow)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function
End Class
