'/*
' * Copyright (c) 2020 Mandelli alessandro.
' * 
' * This program Is free software: you can redistribute it And/Or modify  
' * it under the terms of the GNU General Public License as published by  
' * the Free Software Foundation, version 3. 
' *
' * This program Is distributed in the hope that it will be useful, but 
' * WITHOUT ANY WARRANTY; without even the implied warranty of 
' * MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
' * General Public License for more details.
' *
' * GNU General Public License see <http://www.gnu.org/licenses/>.
' * Date: 24.01.2020
' * Time: 08.57
' */

Imports System.Runtime.CompilerServices

Public Module SliceExtension

    '''<summary>
    '''Slice
    '''</summary>
    '''<param name = "ArrayToBeSliced" > Array to be sliced</param>
    '''<param name="StartPosition">Optional start position of the slice. If none given, then it is assumed as first element of ArrayToBeSliced. Negative values are counted from the last element (e.g. -1 is the last element, -2 is the next to last element, etc.).</param>
    '''<param name="EndPosition">Optional end position of the slice. If none given, then it is assumed as last element of ArrayToBeSliced. Negative values are counted from the last element (e.g. -1 is the last element, -2 is the next to last element, etc.).</param>
    '''<param name="Stepping">Optional stepping through elements of ArrayToBeSliced. If none given, then Stepping=1 is assumed. if StartPosition > EndPosition, then negative Stepping must be provided. If no StartPosition and EndPosition are given, providing Stepping=-1 returns a reverted array.</param>
    '''<returns>Sliced Array</returns>
    '''<remarks>
    '''Slice(start:stop)   items start through stop-1
    '''Slice(start)        items start through the rest of the array
    '''Slice(:stop)        items from the beginning through Stop-1
    '''Slice(:)            a copy of the whole array
    '''Slice(start:stop:step)  start to stop-1, step by step 
    '''</remarks>

    <Extension()>
    Public Function Slice(Of T)(ArrayToBeSliced() As T, Optional StartPosition As Integer = 0, Optional EndPosition As Integer = 0, Optional Stepping As Integer = 1) As T()

        Dim Len As Integer = ArrayToBeSliced.Length
        Dim returnArray() As T = {}

        If StartPosition < 0 Then
            StartPosition = Len + StartPosition
        Else
            StartPosition = idx(len:=Len, pos:=StartPosition)
            EndPosition = idx(Len, EndPosition, Len)
        End If
        If EndPosition = 0 Then
            EndPosition = Len
        ElseIf EndPosition < 0 Then
            EndPosition = Len + EndPosition
        End If


        Dim elemento As Integer = 0

        If (StartPosition < EndPosition And Stepping > 0) Or (EndPosition < StartPosition And Stepping < 0) Then
            While (StartPosition < EndPosition And Stepping > 0) Or (EndPosition < StartPosition And Stepping < 0)
                Array.Resize(returnArray, returnArray.Length + 1)
                returnArray(elemento) = ArrayToBeSliced(StartPosition)
                elemento += 1
                StartPosition += Stepping
            End While
        ElseIf (StartPosition < EndPosition And Stepping < 0) Then
            While (StartPosition < EndPosition And Stepping < 0)
                Array.Resize(returnArray, returnArray.Length + 1)
                returnArray(elemento) = ArrayToBeSliced(EndPosition - 1)
                elemento += 1
                EndPosition += Stepping
            End While
        End If

        Return returnArray

    End Function

    Private Function idx(ByVal len As Integer, pos As Integer, Optional termine As Integer = 0) As Integer

        If IsNothing(pos) Then
            pos = termine Or 0
        ElseIf (pos < 0) Then
            pos = Math.Max(len + pos, 0)
        ElseIf pos = 0 And termine < 0 Then
            pos = len
        Else
            pos = Math.Min(pos, len)
        End If
        Return pos

    End Function

End Module

