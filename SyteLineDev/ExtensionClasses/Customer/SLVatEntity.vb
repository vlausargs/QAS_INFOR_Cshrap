Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.IO
Imports System.Data.SqlClient

Public Class SLVatEntity
    Private _ubAction As Byte
    Private _invNum As String
    Private _cNVATInvNum As String
    Private _cNVATSalesTax As Decimal
    Private _salesTax As Decimal


    Public Property UbAction As Byte
        Get
            Return _ubAction
        End Get
        Set(value As Byte)
            _ubAction = value
        End Set
    End Property



    Public Property InvNum As String
        Get
            Return _invNum
        End Get
        Set(value As String)
            _invNum = value
        End Set
    End Property

    Public Property CNVATInvNum As String
        Get
            Return _cNVATInvNum
        End Get
        Set(value As String)
            _cNVATInvNum = value
        End Set
    End Property
    Public Property CNVATSalesTax As Decimal
        Get
            Return _cNVATSalesTax
        End Get
        Set(value As Decimal)
            _cNVATSalesTax = value
        End Set
    End Property
    Public Property SalesTax As Decimal
        Get
            Return _salesTax
        End Get
        Set(value As Decimal)
            _salesTax = value
        End Set
    End Property
End Class
