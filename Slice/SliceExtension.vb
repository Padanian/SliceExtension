Imports System.Runtime.CompilerServices

Public Module SliceExtension

    <Extension()>
    Public Function Slice(Of T)(brr() As T, Optional inizio As Integer = 0, Optional fine As Integer = 0) As T()

        Dim Len As Integer = brr.Length
        Dim returnArray() As T = {}

        If inizio < 0 Then
            inizio = Len + inizio
            If fine = 0 Then
                fine = Len
            ElseIf fine < 0 Then
                fine = Len + fine
            End If
        Else
            inizio = idx(len:=Len, pos:=inizio)
            fine = idx(Len, fine, Len)
        End If


        Dim elemento As Integer = 0
        While (inizio < fine)
            Array.Resize(returnArray, returnArray.Length + 1)
            returnArray(elemento) = brr(inizio)
            elemento += 1
            inizio += 1
        End While

        Return returnArray

    End Function

    Public Function idx(ByVal len As Integer, pos As Integer, Optional termine As Integer = 0) As Integer

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

