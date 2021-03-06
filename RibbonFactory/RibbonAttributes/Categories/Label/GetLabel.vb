﻿Namespace RibbonAttributes.Categories.Label
    Friend NotInheritable Class GetLabel
        Inherits Label

        Private ReadOnly Callback As String

        Public Sub New(Value As String, Callback As FromControl(Of String))
            MyBase.New(Value)
            Me.Callback = Callback.Method.Name
        End Sub

        Public Sub SetValue(Value As String)
            If Not Me.Value.Equals(Value) Then
                Me.Value = Value
            End If
        End Sub

        Public Overrides ReadOnly Property XML As String
            Get
                Return String.Format(XML_TEMPLATE, CamelCase(NameOf(GetLabel)), Callback)
            End Get
        End Property
    End Class
End Namespace