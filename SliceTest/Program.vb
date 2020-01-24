Imports System
Imports System.Runtime.CompilerServices
Imports SliceClass.SliceExtension
Module Program
    Sub Main()
        Dim arr() As String = {"10", "20", "30", "40", "50", "60", "70", "80", "90", "100"}

        Console.WriteLine("Complete array: " & String.Join(",", arr))


        Console.WriteLine("Array.Slice(-1) = last item in the array: " & String.Join(",", arr.Slice(-1)))
        Console.WriteLine("Array.Slice(-2) = last two items In the array: " & String.Join(",", arr.Slice(-2)))
        Console.WriteLine("Array.Slice(, -2) = everything except the last two items: " & String.Join(",", arr.Slice(, -2)))
        Console.WriteLine("Array.Slice(,, -1) = all items In the array, reversed: " & String.Join(",", arr.Slice(,, -1)))
        Console.WriteLine("Array.Slice(1,, -1) = everything except the first item, reversed: " & String.Join(",", arr.Slice(1,, -1)))
        Console.WriteLine("Array.Slice(, -3, -1) = everything except the last three items, reversed: " & String.Join(",", arr.Slice(, -3, -1)))
        Console.WriteLine("Array.Slice(-3,, -1) = the last three items, reversed: " & String.Join(",", arr.Slice(-3,, -1)))
        Console.WriteLine("Array.Slice(1,, 2) = even elements: " & String.Join(",", arr.Slice(1, , 2)))
        Console.WriteLine("Array.Slice(0,, 2) = odd elements: " & String.Join(",", arr.Slice(0, , 2)))



    End Sub
End Module
