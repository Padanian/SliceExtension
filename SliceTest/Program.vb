Imports System
Imports System.Runtime.CompilerServices
Imports SliceClass.SliceExtension
Module Program
    Sub Main()
        Dim arr() As String = {"10", "20", "30", "40", "50", "60", "70"}
        Dim retarr() As Object = arr.Slice(-3, -1)
        Console.WriteLine(retarr.ToString)
    End Sub
End Module
