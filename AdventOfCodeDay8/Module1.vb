Imports System.IO

Module Module1

    Structure Node
        Dim value As String
        Dim destination1 As String
        Dim destination2 As String
    End Structure

    Sub Main()
        Dim instructions As String = "LLRLRRRLLLRLRRLRRRLRLRRLRLRLRRRLRRRLRLRLRRLLRRRLRRLRRLLRLRRRLRLRLLRRRLLRRRLRLRRRLRRRLRRRLLLRRRLRRLRRLRLRRLRLRRRLRLRRLRLRLRRRLRLLLRRRLLLRLRRRLRLRRLRLRLRLRRLRRLRRLRLRRRLRRRLRRLRRRLRRLRRLRRRLLRLRRLLLRRLRRLRLRLLLRRLRRLRRRLRRLLRLRRRLRRRLRRLRRLRLRRLRLRRRLRRLRRRLLRRRLRLRLLLRRRLLLRRLLRRLRLRRLRLLLRRRR"
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day8Input.txt")
        'Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day8Test.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim nodes(0) As Node
        Dim i As Integer = 0
        Dim manySplit As String()
        Dim currentPosition As Integer
        Dim stepCount(0) As Integer
        Dim instructionPosition As Integer
        Dim startPosition(0) As String
        Dim manySplit2 As String()


        Do
            ReDim Preserve nodes(i)
            nodes(i).value = textInput.Substring(0, 3)
            nodes(i).destination1 = textInput.Substring(7, 3)
            nodes(i).destination2 = textInput.Substring(12, 3)

            i += 1
            textInput = fileReader.ReadLine()
        Loop Until textInput = ""
        Dim sortQuery = From n In nodes
                        Order By StrReverse(n.value) Ascending
                        Select n

        Dim sb As New System.Text.StringBuilder()
        Dim a = 0
        For Each node As Node In sortQuery
            Console.WriteLine(node.value)
            sb.Append(node.value & " " & node.destination1 & " " & node.destination2 & " ")
            a += 1
        Next

        manySplit = Split(sb.ToString)
        For i = 0 To manySplit.Length - 4 Step 3
            nodes(i / 3).value = manySplit(i)
            nodes(i / 3).destination1 = manySplit(i + 1)
            nodes(i / 3).destination2 = manySplit(i + 2)
        Next

        For a = 0 To nodes.Length - 1
            If nodes(a).value.Substring(2, 1) = "A" Then
                ReDim Preserve startPosition(a)
                startPosition(a) = a
            End If
        Next

        For b = 0 To startPosition.Length - 1
            currentPosition = startPosition(b)
            ReDim Preserve stepCount(b)
            Do Until nodes(currentPosition).value.Substring(2, 1) = "Z"
                currentPosition = FindNextPosition(nodes(currentPosition), nodes, instructions, instructionPosition)
                stepCount(b) += 1
                instructionPosition += 1
                If instructionPosition >= instructions.Length Then
                    instructionPosition = 0
                End If
            Loop
        Next

        For i = 0 To stepCount.Length - 1
            Console.WriteLine(stepCount(i))
        Next
        'Find the LCM of stepCount to get your answer 
        Console.ReadLine()
    End Sub

    Function FindNextPosition(node As Node, nodes As Node(), instructions As String, instructPos As Integer)
        Dim direction As Char = instructions(instructPos)
        Dim destination As String
        Dim position As Integer

        If direction = "R" Then
            destination = node.destination2
        Else
            destination = node.destination1
        End If

        position = BinarySearch(nodes, destination)
        Return position

    End Function

    Function BinarySearch(nodes As Node(), Target As String)

        Dim iLow As Integer, iHigh As Integer, iMiddle As Integer

        iLow = LBound(nodes)
        iHigh = UBound(nodes)

        Do While iLow <= iHigh
            iMiddle = (iLow + iHigh) / 2
            If Target = nodes(iMiddle).value Then
                Return iMiddle
            ElseIf StrReverse(Target) < StrReverse(nodes(iMiddle).value) Then
                iHigh = (iMiddle - 1)
            Else
                iLow = (iMiddle + 1)
            End If
        Loop


    End Function
End Module

Module Module2

    Structure Node
        Dim value As String
        Dim destination1 As String
        Dim destination2 As String
    End Structure

    Sub Main()
        Dim instructions As String = "LLRLRRRLLLRLRRLRRRLRLRRLRLRLRRRLRRRLRLRLRRLLRRRLRRLRRLLRLRRRLRLRLLRRRLLRRRLRLRRRLRRRLRRRLLLRRRLRRLRRLRLRRLRLRRRLRLRRLRLRLRRRLRLLLRRRLLLRLRRRLRLRRLRLRLRLRRLRRLRRLRLRRRLRRRLRRLRRRLRRLRRLRRRLLRLRRLLLRRLRRLRLRLLLRRLRRLRRRLRRLLRLRRRLRRRLRRLRRLRLRRLRLRRRLRRLRRRLLRRRLRLRLLLRRRLLLRRLLRRLRLRRLRLLLRRRR"
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day8Input.txt")
        'Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day8Test.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim nodes() As Node
        Dim i As Integer = 0
        Dim manySplit As String()
        Dim currentPosition As Integer
        Dim stepCount As Integer
        Dim instructionPosition As Integer


        Do
            ReDim Preserve nodes(i)
            nodes(i).value = textInput.Substring(0, 3)
            nodes(i).destination1 = textInput.Substring(7, 3)
            nodes(i).destination2 = textInput.Substring(12, 3)

            i += 1
            textInput = fileReader.ReadLine()
        Loop Until textInput = ""
        Dim sortQuery = From n In nodes
                        Order By n.value Ascending
                        Select n

        Dim sb As New System.Text.StringBuilder()
        Dim a = 0
        For Each node As Node In sortQuery
            sb.Append(node.value & " " & node.destination1 & " " & node.destination2 & " ")
            a += 1
        Next
        manySplit = Split(sb.ToString)
        For i = 0 To manySplit.Length - 4 Step 3
            nodes(i / 3).value = manySplit(i)
            nodes(i / 3).destination1 = manySplit(i + 1)
            nodes(i / 3).destination2 = manySplit(i + 2)
        Next

        For b = 0 To 1
            Do Until nodes(currentPosition).value.Substring(2, 1) = "Z"
                currentPosition = FindNextPosition(nodes(currentPosition), nodes, instructions, instructionPosition)
                stepCount += 1
                instructionPosition += 1
                If instructionPosition >= instructions.Length Then
                    instructionPosition = 0
                End If
            Loop
        Next

        Console.WriteLine(stepCount)
        Console.ReadLine()
    End Sub

    Function FindNextPosition(node As Node, nodes As Node(), instructions As String, instructPos As Integer)
        Dim direction As Char = instructions(instructPos)
        Dim destination As String
        Dim position As Integer

        If direction = "R" Then
            destination = node.destination2
        Else
            destination = node.destination1
        End If

        position = BinarySearch(nodes, destination)
        Return position

    End Function

    Function BinarySearch(nodes As Node(), Target As String)

        Dim iLow As Integer, iHigh As Integer, iMiddle As Integer

        iLow = LBound(nodes)
        iHigh = UBound(nodes)

        Do While iLow <= iHigh
            iMiddle = (iLow + iHigh) / 2
            If Target = nodes(iMiddle).value Then
                Return iMiddle
            ElseIf Target < nodes(iMiddle).value Then
                iHigh = (iMiddle - 1)
            Else
                iLow = (iMiddle + 1)
            End If
        Loop


    End Function
End Module
