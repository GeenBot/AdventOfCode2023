Module Module1

    Sub Main()
        Dim totalTime As Double = 41777096
        Dim distance As Double = 249136211271011
        Dim totalDistance As Double
        Dim wins As Double
        Dim finalResult As Double = 1
        For held = 1 To totalTime - 1
            totalDistance = held * (totalTime - held)
            If totalDistance > distance Then
                wins += 1
            End If
        Next
        Console.WriteLine(wins)
        Console.ReadLine()
    End Sub

End Module
Module Module2

    Sub Main()
        Dim totalTime As Integer() = {41, 77, 70, 96}
        Dim distance As Integer() = {249, 1362, 1127, 1011}
        Dim totalDistance As Integer
        Dim wins As Integer
        Dim finalWins(totalTime.Length - 1) As Integer
        Dim finalResult As Integer = 1

        For a = 0 To totalTime.Length - 1
            wins = 0
            For held = 1 To totalTime(a) - 1
                totalDistance = held * (totalTime(a) - held)
                If totalDistance > distance(a) Then
                    wins += 1
                End If
            Next
            finalWins(a) = wins
        Next

        For a = 0 To totalTime.Length - 1
            finalResult = finalResult * finalWins(a)
        Next

        Console.WriteLine(finalResult)
        Console.ReadLine()
    End Sub

End Module
