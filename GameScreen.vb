Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class GameScreen

    Private Const m_nDiceSides As Integer = 12
    Private Const m_nRollsPerTurn As Integer = 4

    Private m_cOpenColor = Color.AliceBlue
    Private m_cSetColor = Color.DodgerBlue
    Private m_cInertColor = SystemColors.Control

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

    Private Sub PlayTurn()

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
                cmdRollDice.Text = "Start Over"

            Case 0
                'keep going 

                'go for quad?
                If MyTurn.nRollNumber = 2 And CyboLines(MyTurn.nEstablishedLine).Length = 4 Then
                    cmdRollDice.Text = "Start Over"
                    cmdRollQuad.Visible = True
                End If

                'evaluate points
                Select Case MyTurn.nRollNumber + 1
                    Case 3
                        MyTurn.nPoints = 3
                        Debug.WriteLine("You scored {0} points!", MyTurn.nPoints)
                    Case 4
                        MyTurn.nPoints = 16
                        Debug.WriteLine("You scored {0} points!", MyTurn.nPoints)
                End Select

                MyTurn.nRollNumber += 1
        End Select

        'SetCellColor(nRoll, m_cSetColor)

        'show all available lines

    End Sub

    ' Evaluate current turn based on CyboLines map
    ' 
    ' Returns:
    '     0 - Turn can continue, no points awarded yet
    '    -1 - Turn is over, results are not in a line
    '     n - Points this turn is awarded
    Private Function EvalResults(ByRef theTurn As TurnInfo) As Integer

        Dim nLineNum As Integer = 0
        Dim nLineHits As Integer = 0
        Dim nEval As Integer = 0

        'init board
        For i As Integer = 1 To m_nDiceSides
            SetCellColor(i, m_cInertColor)
        Next

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

            'show possible lines
            If nHits = theTurn.nRollNumber + 1 Then
                For Each nNumber As Integer In CyboLines(nLineNum)
                    SetCellColor(nNumber, m_cOpenColor)
                Next

            End If

            'track hit count for best line
            If nHits > nLineHits Then
                nLineHits = nHits
                theTurn.nEstablishedLine = nLineNum
            End If
        Next

        'set current roll results to blue
        For i As Integer = 0 To theTurn.nRollNumber
            SetCellColor(theTurn.nResults(i), m_cSetColor)
        Next

        'how we doing?
        If nLineHits < theTurn.nRollNumber + 1 Then
            'turn is lost
            nEval = -1
        Else
            'keep going
            nEval = 0
        End If

        Debug.WriteLine("")
        Debug.WriteLine("RollNumber: {0}", theTurn.nRollNumber + 1)
        Debug.WriteLine("LineHits: {0}", nLineHits)
        Debug.WriteLine("Eval: {0}", nEval)

        Return nEval

    End Function


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

    Private Function RollDice(nDiceSides As Integer) As Integer
        'Dim nNums As Integer() = {1, 2, 3, 4}
        Static oRandom As New Random(Now.Millisecond)
        Return oRandom.Next(1, nDiceSides + 1)
        'Return nNums(MyTurn.nRollNumber)
    End Function

    Private Function RollDice_rngCsp(numberSides As UInt16) As UInt16
        Dim rngCsp As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim randomBytes As Byte() = New Byte(1) {}
        rngCsp.GetBytes(randomBytes)
        Return CUShort((BitConverter.ToUInt16(randomBytes, 0) Mod numberSides) + 1)
    End Function

    Private Sub cmdRollDice_Click(sender As Object, e As EventArgs) Handles cmdRollDice.Click
        If cmdRollDice.Text = "Start Over" Then
            ClearTurn()
            cmdRollDice.Text = "Roll Dice"
        Else
            PlayTurn()
        End If
        'Timer1.Enabled = Not Timer1.Enabled
    End Sub


    Private Sub ClearBoard()
        For i As Integer = 1 To m_nDiceSides
            SetCellColor(i, m_cOpenColor)
        Next
    End Sub

    Private Sub ClearTurn()

        ClearBoard()

        cmdRollQuad.Visible = False

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
    End Sub

    Private Sub cmdRollQuad_Click(sender As Object, e As EventArgs) Handles cmdRollQuad.Click
        PlayTurn()
        cmdRollQuad.Visible = False
    End Sub
End Class