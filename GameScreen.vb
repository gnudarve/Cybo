Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class GameScreen

    Private Const m_nDiceSides As Integer = 12
    Private Const m_nRollsPerTurn As Integer = 4

    Private m_cOpenColor = Color.AliceBlue
    Private m_cSetColor = Color.DodgerBlue
    Private m_cInertColor = SystemColors.Control

    Private m_rngCsp As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()

    Private m_Board As Label()
    Private m_Tally As Label()

    Private MyTurn As New TurnInfo With {
            .nResults = New Integer(m_nRollsPerTurn - 1) {}
        }

    Private Structure TurnInfo
        Public nRollNumber As Integer
        Public nPoints As Integer
        Public nEstablishedLine As Integer
        Public nResults As Integer()
    End Structure

    Private CyboLines As Byte()() = New Byte()() {
        New Byte() {1, 5, 9},
        New Byte() {2, 6, 10},
        New Byte() {3, 7, 11},
        New Byte() {4, 8, 12},
        New Byte() {1, 2, 3, 4},
        New Byte() {5, 6, 7, 8},
        New Byte() {9, 10, 11, 12},
        New Byte() {2, 7, 12},
        New Byte() {1, 6, 11},
        New Byte() {3, 6, 9},
        New Byte() {4, 7, 10}
    }

    Private Sub GameScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        m_Board = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12}
        m_Tally = {Tally1, Tally2, Tally3, tally4, Tally5, tally6, Tally7, tally8, Tally9, Tally10, Tally11, Tally12}

        ClearTurn()

    End Sub


    Private Function IsDuplicate(theTurn As TurnInfo) As Boolean

        For nRoll As Integer = 0 To theTurn.nRollNumber - 1
            If theTurn.nResults(nRoll) = theTurn.nResults(theTurn.nRollNumber) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Sub RollTest_ShowLines()

        Static nLastRoll As Integer = 0
        Dim nRoll As Integer
        Dim nEval As Integer

        'roll dice
        Do
            nRoll = RollDice(m_nDiceSides)
        Loop While nRoll = nLastRoll
        nLastRoll = nRoll

        MyTurn.nResults(MyTurn.nRollNumber) = nRoll

        ' check for same number hit twice
        If IsDuplicate(MyTurn) Then
            Debug.WriteLine("Duplicate number.")
            nEval = -1
        Else
            nEval = EvalResults(MyTurn)
        End If


        Select Case nEval
            Case -1
                Debug.WriteLine("Out of line.")
                MyTurn.nPoints = 0

            Case 0
                'keep going 
                MyTurn.nRollNumber += 1

            Case Else
                Debug.WriteLine("Line {0}: Turn is over, you scored: {1}!", MyTurn.nEstablishedLine, MyTurn.nPoints)
                MyTurn.nPoints = nEval

        End Select

        SetCellColor(nRoll, m_cSetColor)

        'show all available lines

    End Sub

    Private Sub RollTest()

        Static nLastRoll As Integer = 0
        Dim nRoll As Integer

        'ClearBoard()
        SetCellColor(nLastRoll, m_cInertColor)

        'Do
        nRoll = RollDice(m_nDiceSides)
        'Loop While nRoll = nLastRoll
        nLastRoll = nRoll

        SetCellColor(nRoll, m_cSetColor)
        m_Tally(nRoll - 1).Text = (CInt(m_Tally(nRoll - 1).Text) + 1).ToString

    End Sub

    ' Evaluate current turn based on CyboLines map
    ' 
    ' Returns:
    '     0 - Turn can continue, no points awarded yet
    '    -1 - Turn is over, results are not in a line
    '     n - Points this turn is awarded
    Private Function EvalResults(theTurn As TurnInfo) As Integer
        Dim nLineNum As Integer = 0
        Dim nLineHits As Integer = 0
        Dim nPoints As Integer = 0

        ' see if the rolls are in the same line
        For nLineNum = 0 To CyboLines.GetLength(0) - 1
            Dim nHits As Integer = 0
            For Each nNumber As Integer In CyboLines(nLineNum)
                For nRoll As Integer = 0 To theTurn.nRollNumber
                    If theTurn.nResults(nRoll) = nNumber Then
                        nHits += 1
                    End If
                Next
            Next

            If nHits = theTurn.nRollNumber + 1 Then
                Dim sSequence As String = ""
                For Each nNumber As Integer In CyboLines(nLineNum)
                    sSequence += (nNumber.ToString() + " ")
                Next
                Debug.WriteLine("Possible Line {0}: {1}", nLineNum + 1, sSequence)

                If nHits > nLineHits Then
                    nLineHits = nHits
                    theTurn.nEstablishedLine = nLineNum
                End If
            End If
        Next

        ' evaluate points
        Select Case theTurn.nRollNumber
            Case 0, 1
                nPoints = 0
            Case 2
                nPoints = 3
            Case 3
                nPoints = 16
        End Select

        Return nPoints

    End Function


    ' This method simulates a roll of the dice. The input parameter is the
    ' number of sides of the dice.
    Private Function RollDice(nDiceSides As Integer) As Integer
        Static oRandom As New Random(Now.Millisecond)
        Return oRandom.Next(1, nDiceSides + 1)
    End Function

    ' This method simulates a roll of the dice. The input parameter is the
    ' number of sides of the dice.
    Private Function RollDice(ByVal numberSides As UInt16) As UInt16
        Dim randomBytes As Byte() = New Byte(1) {}
        m_rngCsp.GetBytes(randomBytes)
        Return CUShort((BitConverter.ToUInt16(randomBytes, 0) Mod numberSides) + 1)
    End Function

    Private Sub cmdRollDice_Click(sender As Object, e As EventArgs) Handles cmdRollDice.Click
        RollTest_ShowLines()
        'Timer1.Enabled = Not Timer1.Enabled
    End Sub


    Private Sub ClearTurn()
        For i As Integer = 1 To m_nDiceSides
            SetCellColor(i, m_cOpenColor)
        Next

        MyTurn.nEstablishedLine = -1
        MyTurn.nPoints = 0
        MyTurn.nRollNumber = 0
        For i As Integer = 0 To m_nRollsPerTurn - 1
            MyTurn.nResults(i) = 0
        Next
    End Sub

    Private Sub SetCellColor(nCellNumber As Integer, nTargetColor As Color)
        If nCellNumber >= 1 AndAlso nCellNumber <= m_Board.Length Then
            m_Board(nCellNumber - 1).BackColor = nTargetColor
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RollTest()
        RollTest_ShowLines()
    End Sub

End Class