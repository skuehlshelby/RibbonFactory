﻿Imports System.Drawing
Imports RibbonFactory.BuilderInterfaces
Imports RibbonFactory.Controls
Imports RibbonFactory.Enums.ImageMSO
Imports RibbonFactory.Enums.MSO
Imports stdole

Namespace Builders

    Public Class EditBoxBuilder
        Inherits Builder(Of EditBox)
        Implements ISetEnabled(Of EditBoxBuilder)
        Implements ISetVisibility(Of EditBoxBuilder)
        Implements ISetInsertionPoint(Of EditBoxBuilder)
        Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder)
        Implements ISetKeyTip(Of EditBoxBuilder)
        Implements ISetImage(Of EditBoxBuilder)
        Implements ISetLabelVisibility(Of EditBoxBuilder)
        Implements ISetMaxLength(Of EditBoxBuilder)
        Implements ISetTextChangeAction(Of EditBoxBuilder)

        Public Overrides Function Build(tag As Object) As EditBox
            Return New EditBox(attributes:=Attributes, tag:=tag)
        End Function

        Public Function Enabled() As EditBoxBuilder Implements ISetEnabled(Of EditBoxBuilder).Enabled
            AddEnabled(enabled:=True)
            Return Me
        End Function

        Public Function Enabled(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetEnabled(Of EditBoxBuilder).Enabled
            AddEnabled(enabled:=True, callback:=callback)
            Return Me
        End Function

        Public Function Disabled() As EditBoxBuilder Implements ISetEnabled(Of EditBoxBuilder).Disabled
            AddEnabled(enabled:=False)
            Return Me
        End Function

        Public Function Disabled(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetEnabled(Of EditBoxBuilder).Disabled
            AddEnabled(enabled:=False, callback:=callback)
            Return Me
        End Function

        Public Function Visible() As EditBoxBuilder Implements ISetVisibility(Of EditBoxBuilder).Visible
            AddVisible(visible:=True)
            Return Me
        End Function

        Public Function Visible(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetVisibility(Of EditBoxBuilder).Visible
            AddVisible(visible:=True, callback:=callback)
            Return Me
        End Function

        Public Function Invisible() As EditBoxBuilder Implements ISetVisibility(Of EditBoxBuilder).Invisible
            AddVisible(visible:=False)
            Return Me
        End Function

        Public Function Invisible(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetVisibility(Of EditBoxBuilder).Invisible
            AddVisible(visible:=False, callback:=callback)
            Return Me
        End Function

        Public Function WithLabel(label As String, Optional copyToScreenTip As Boolean = True) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithLabel
            AddLabel(label:=label)

            If copyToScreenTip Then
                AddScreenTip(screenTip:=label)
            End If

            Return Me
        End Function

        Public Function WithLabel(label As String, callback As FromControl(Of String), Optional copyToScreenTip As Boolean = True) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithLabel
            AddLabel(label:=label, callback:=callback)

            If copyToScreenTip Then
                AddScreenTip(screenTip:=label, callback:=callback)
            End If

            Return Me
        End Function

        Public Function WithScreenTip(screenTip As String) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithScreenTip
            AddScreenTip(screenTip:=screenTip)
            Return Me
        End Function

        Public Function WithScreenTip(screenTip As String, callback As FromControl(Of String)) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithScreenTip
            AddScreenTip(screenTip:=screenTip, callback:=callback)
            Return Me
        End Function

        Public Function WithSuperTip(superTip As String) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithSuperTip
            AddSuperTip(superTip:=superTip)
            Return Me
        End Function

        Public Function WithSuperTip(superTip As String, callback As FromControl(Of String)) As EditBoxBuilder Implements ISetLabelScreenTipAndSuperTip(Of EditBoxBuilder).WithSuperTip
            AddSuperTip(superTip:=superTip, callback:=callback)
            Return Me
        End Function

        Public Function WithKeyTip(keyTip As KeyTip) As EditBoxBuilder Implements ISetKeyTip(Of EditBoxBuilder).WithKeyTip
            AddKeyTip(keyTip)
            Return Me
        End Function

        Public Function WithKeyTip(keyTip As KeyTip, callback As FromControl(Of KeyTip)) As EditBoxBuilder Implements ISetKeyTip(Of EditBoxBuilder).WithKeyTip
            AddKeyTip(keyTip, callback:=callback)
            Return Me
        End Function

        Public Function WithImage(image As ImageMSO) As EditBoxBuilder Implements ISetImage(Of EditBoxBuilder).WithImage
            AddImage(image)
            Return Me
        End Function

        Public Function WithImage(image As IPictureDisp, callback As FromControl(Of IPictureDisp)) As EditBoxBuilder Implements ISetImage(Of EditBoxBuilder).WithImage
            AddImage(image, callback:=callback)
            Return Me
        End Function

        Public Function WithImage(image As Bitmap, callback As FromControl(Of IPictureDisp)) As EditBoxBuilder Implements ISetImage(Of EditBoxBuilder).WithImage
            AddImage(image, callback:=callback)
            Return Me
        End Function

        Public Function ShowLabel() As EditBoxBuilder Implements ISetLabelVisibility(Of EditBoxBuilder).ShowLabel
            AddShowLabel(showLabel:=True)
            Return Me
        End Function

        Public Function ShowLabel(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetLabelVisibility(Of EditBoxBuilder).ShowLabel
            AddShowLabel(showLabel:=True, callback:=callback)
            Return Me
        End Function

        Public Function HideLabel() As EditBoxBuilder Implements ISetLabelVisibility(Of EditBoxBuilder).HideLabel
            AddShowLabel(showLabel:=False)
            Return Me
        End Function

        Public Function HideLabel(callback As FromControl(Of Boolean)) As EditBoxBuilder Implements ISetLabelVisibility(Of EditBoxBuilder).HideLabel
            AddShowLabel(showLabel:=False, callback:=callback)
            Return Me
        End Function

        Public Function OfWidth(limit As Byte) As EditBoxBuilder Implements ISetMaxLength(Of EditBoxBuilder).OfWidth
            AddMaxLength(limit)
            Return Me
        End Function

        Public Function ThatDoes(callback As TextChanged, action As Action) As EditBoxBuilder Implements ISetTextChangeAction(Of EditBoxBuilder).ThatDoes
            AddAction(callback:=callback, action:=action)
            Return Me
        End Function

        Public Function InsertBeforeMSO(builtInControl As MSO) As EditBoxBuilder Implements ISetInsertionPoint(Of EditBoxBuilder).InsertBefore
            InsertBefore(builtInControl)
            Return Me
        End Function

        Public Function InsertBeforeQ(qualifiedControl As RibbonElement) As EditBoxBuilder Implements ISetInsertionPoint(Of EditBoxBuilder).InsertBefore
            InsertBefore(qualifiedControl)
            Return Me
        End Function

        Public Function InsertAfterMSO(builtInControl As MSO) As EditBoxBuilder Implements ISetInsertionPoint(Of EditBoxBuilder).InsertAfter
            InsertAfter(builtInControl)
            Return Me
        End Function

        Public Function InsertAfterQ(qualifiedControl As RibbonElement) As EditBoxBuilder Implements ISetInsertionPoint(Of EditBoxBuilder).InsertAfter
            InsertAfter(qualifiedControl)
            Return Me
        End Function
    End Class
End Namespace