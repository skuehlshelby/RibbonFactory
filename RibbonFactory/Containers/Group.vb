﻿Imports RibbonFactory.Component_Interfaces
Imports RibbonFactory.RibbonAttributes
Imports RibbonFactory.RibbonAttributes.Categories.ID
Imports RibbonFactory.RibbonAttributes.Categories.Image
Imports RibbonFactory.RibbonAttributes.Categories.KeyTip
Imports RibbonFactory.RibbonAttributes.Categories.Label
Imports RibbonFactory.RibbonAttributes.Categories.Screentip
Imports RibbonFactory.RibbonAttributes.Categories.SuperTip
Imports RibbonFactory.RibbonAttributes.Categories.Visible
Imports stdole

Namespace Containers

    Public Class Group
        Inherits RibbonElement
        Implements ILabel
        Implements IVisible
        Implements IKeyTip
        Implements IImage
        Implements IScreenTip
        Implements ISuperTip
        Implements IList(Of RibbonElement)

        Private ReadOnly _items As List(Of RibbonElement) = New List(Of RibbonElement)()
        Private ReadOnly _attributes As AttributeGroup

        Friend Sub New(attributes As AttributeGroup, Optional tag As Object = Nothing)
            MyBase.New(tag)
            _attributes = attributes
        End Sub

        Public Overrides ReadOnly Property ID As String
            Get
                Return _attributes.Lookup(Of Id).GetValue()
            End Get
        End Property

        Public Overrides ReadOnly Property XML As String
            Get
                Return _
                    String.Join(Environment.NewLine, $"<{NameOf(Group).ToLower()} {String.Join(" ", _attributes) }>",
                                String.Join(Environment.NewLine, _items), $"</{NameOf(Group).ToLower()}>")
            End Get
        End Property

        Public Property Label As String Implements ILabel.Label
            Get
                Return _attributes.Lookup(Of Label).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetLabel).SetValue(Value)
            End Set
        End Property

        Public Property Visible As Boolean Implements IVisible.Visible
            Get
                Return _attributes.Lookup(Of Visible).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetVisible).SetValue(Value)
            End Set
        End Property

        Default Public Property Item(index As Integer) As RibbonElement Implements IList(Of RibbonElement).Item
            Get
                Return DirectCast(_items, IList(Of RibbonElement))(index)
            End Get
            Set
                DirectCast(_items, IList(Of RibbonElement))(index) = value
            End Set
        End Property

        Public ReadOnly Property Count As Integer Implements ICollection(Of RibbonElement).Count
            Get
                Return DirectCast(_items, ICollection(Of RibbonElement)).Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of RibbonElement).IsReadOnly
            Get
                Return DirectCast(_items, ICollection(Of RibbonElement)).IsReadOnly
            End Get
        End Property

        Public Property KeyTip As KeyTip Implements IKeyTip.KeyTip
            Get
                Return _attributes.Lookup(Of Categories.KeyTip.KeyTip).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetKeyTip).SetValue(value)
                Refresh()
            End Set
        End Property

        Public Property Image As IPictureDisp Implements IImage.Image
            Get
                Return _attributes.Lookup(Of GetImage).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetImage).SetValue(value)
                Refresh()
            End Set
        End Property

        Public ReadOnly Property IsCustom As Boolean Implements IImage.IsCustom
            Get
                Return TypeOf _attributes.Lookup(Of ImageBase) Is GetImage
            End Get
        End Property

        Public Property ScreenTip As String Implements IScreenTip.ScreenTip
            Get
                Return _attributes.Lookup(Of ScreenTip).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetScreenTip).SetValue(value)
                Refresh()
            End Set
        End Property

        Public Property SuperTip As String Implements ISuperTip.SuperTip
            Get
                Return _attributes.Lookup(Of SuperTip).GetValue()
            End Get
            Set
                _attributes.Lookup(Of GetSuperTip).SetValue(value)
                Refresh()
            End Set
        End Property

        Public Sub Insert(index As Integer, element As RibbonElement) Implements IList(Of RibbonElement).Insert
            DirectCast(_items, IList(Of RibbonElement)).Insert(index, element)
        End Sub

        Public Sub RemoveAt(index As Integer) Implements IList(Of RibbonElement).RemoveAt
            DirectCast(_items, IList(Of RibbonElement)).RemoveAt(index)
        End Sub

        Public Sub Add(element As RibbonElement) Implements ICollection(Of RibbonElement).Add
            DirectCast(_items, ICollection(Of RibbonElement)).Add(element)
        End Sub

        Public Sub Clear() Implements ICollection(Of RibbonElement).Clear
            DirectCast(_items, ICollection(Of RibbonElement)).Clear()
        End Sub

        Public Sub CopyTo(array() As RibbonElement, arrayIndex As Integer) Implements ICollection(Of RibbonElement).CopyTo
            DirectCast(_items, ICollection(Of RibbonElement)).CopyTo(array, arrayIndex)
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            Return obj.GetHashCode() = GetHashCode() AndAlso TypeOf obj Is Group
        End Function

        Public Function IndexOf(element As RibbonElement) As Integer Implements IList(Of RibbonElement).IndexOf
            Return DirectCast(_items, IList(Of RibbonElement)).IndexOf(element)
        End Function

        Public Function Contains(element As RibbonElement) As Boolean Implements ICollection(Of RibbonElement).Contains
            Return DirectCast(_items, ICollection(Of RibbonElement)).Contains(element)
        End Function

        Public Function Remove(element As RibbonElement) As Boolean Implements ICollection(Of RibbonElement).Remove
            Return DirectCast(_items, ICollection(Of RibbonElement)).Remove(element)
        End Function

        Public Function GetEnumerator() As IEnumerator(Of RibbonElement) Implements IEnumerable(Of RibbonElement).GetEnumerator
            Return DirectCast(_items, IEnumerable(Of RibbonElement)).GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_items, IEnumerable).GetEnumerator()
        End Function
    End Class
End Namespace