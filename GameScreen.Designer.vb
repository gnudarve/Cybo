<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameScreen))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdRollDice = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Tally1 = New System.Windows.Forms.Label()
        Me.Tally2 = New System.Windows.Forms.Label()
        Me.Tally3 = New System.Windows.Forms.Label()
        Me.tally4 = New System.Windows.Forms.Label()
        Me.tally8 = New System.Windows.Forms.Label()
        Me.Tally7 = New System.Windows.Forms.Label()
        Me.tally6 = New System.Windows.Forms.Label()
        Me.Tally5 = New System.Windows.Forms.Label()
        Me.Tally12 = New System.Windows.Forms.Label()
        Me.Tally11 = New System.Windows.Forms.Label()
        Me.Tally10 = New System.Windows.Forms.Label()
        Me.Tally9 = New System.Windows.Forms.Label()
        Me.cmdRollQuad = New System.Windows.Forms.Button()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(362, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(362, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 108)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(362, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 108)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(362, 333)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 108)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(484, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 108)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(484, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 108)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(484, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 108)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(484, 333)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 108)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "8"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(606, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 108)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(606, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 108)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "10"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(606, 225)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 108)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "11"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(606, 333)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 108)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "12"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdRollDice
        '
        Me.cmdRollDice.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!)
        Me.cmdRollDice.Location = New System.Drawing.Point(30, 27)
        Me.cmdRollDice.Name = "cmdRollDice"
        Me.cmdRollDice.Size = New System.Drawing.Size(297, 62)
        Me.cmdRollDice.TabIndex = 12
        Me.cmdRollDice.Text = "Roll Dice"
        Me.cmdRollDice.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Tally1
        '
        Me.Tally1.AutoSize = True
        Me.Tally1.Location = New System.Drawing.Point(369, 90)
        Me.Tally1.Name = "Tally1"
        Me.Tally1.Size = New System.Drawing.Size(16, 17)
        Me.Tally1.TabIndex = 13
        Me.Tally1.Text = "0"
        Me.Tally1.Visible = False
        '
        'Tally2
        '
        Me.Tally2.AutoSize = True
        Me.Tally2.Location = New System.Drawing.Point(369, 199)
        Me.Tally2.Name = "Tally2"
        Me.Tally2.Size = New System.Drawing.Size(16, 17)
        Me.Tally2.TabIndex = 14
        Me.Tally2.Text = "0"
        Me.Tally2.Visible = False
        '
        'Tally3
        '
        Me.Tally3.AutoSize = True
        Me.Tally3.Location = New System.Drawing.Point(369, 305)
        Me.Tally3.Name = "Tally3"
        Me.Tally3.Size = New System.Drawing.Size(16, 17)
        Me.Tally3.TabIndex = 15
        Me.Tally3.Text = "0"
        Me.Tally3.Visible = False
        '
        'tally4
        '
        Me.tally4.AutoSize = True
        Me.tally4.Location = New System.Drawing.Point(369, 415)
        Me.tally4.Name = "tally4"
        Me.tally4.Size = New System.Drawing.Size(16, 17)
        Me.tally4.TabIndex = 16
        Me.tally4.Text = "0"
        Me.tally4.Visible = False
        '
        'tally8
        '
        Me.tally8.AutoSize = True
        Me.tally8.Location = New System.Drawing.Point(490, 415)
        Me.tally8.Name = "tally8"
        Me.tally8.Size = New System.Drawing.Size(16, 17)
        Me.tally8.TabIndex = 20
        Me.tally8.Text = "0"
        Me.tally8.Visible = False
        '
        'Tally7
        '
        Me.Tally7.AutoSize = True
        Me.Tally7.Location = New System.Drawing.Point(490, 305)
        Me.Tally7.Name = "Tally7"
        Me.Tally7.Size = New System.Drawing.Size(16, 17)
        Me.Tally7.TabIndex = 19
        Me.Tally7.Text = "0"
        Me.Tally7.Visible = False
        '
        'tally6
        '
        Me.tally6.AutoSize = True
        Me.tally6.Location = New System.Drawing.Point(490, 199)
        Me.tally6.Name = "tally6"
        Me.tally6.Size = New System.Drawing.Size(16, 17)
        Me.tally6.TabIndex = 18
        Me.tally6.Text = "0"
        Me.tally6.Visible = False
        '
        'Tally5
        '
        Me.Tally5.AutoSize = True
        Me.Tally5.Location = New System.Drawing.Point(490, 90)
        Me.Tally5.Name = "Tally5"
        Me.Tally5.Size = New System.Drawing.Size(16, 17)
        Me.Tally5.TabIndex = 17
        Me.Tally5.Text = "0"
        Me.Tally5.Visible = False
        '
        'Tally12
        '
        Me.Tally12.AutoSize = True
        Me.Tally12.Location = New System.Drawing.Point(612, 415)
        Me.Tally12.Name = "Tally12"
        Me.Tally12.Size = New System.Drawing.Size(16, 17)
        Me.Tally12.TabIndex = 24
        Me.Tally12.Text = "0"
        Me.Tally12.Visible = False
        '
        'Tally11
        '
        Me.Tally11.AutoSize = True
        Me.Tally11.Location = New System.Drawing.Point(612, 305)
        Me.Tally11.Name = "Tally11"
        Me.Tally11.Size = New System.Drawing.Size(16, 17)
        Me.Tally11.TabIndex = 23
        Me.Tally11.Text = "0"
        Me.Tally11.Visible = False
        '
        'Tally10
        '
        Me.Tally10.AutoSize = True
        Me.Tally10.Location = New System.Drawing.Point(612, 199)
        Me.Tally10.Name = "Tally10"
        Me.Tally10.Size = New System.Drawing.Size(16, 17)
        Me.Tally10.TabIndex = 22
        Me.Tally10.Text = "0"
        Me.Tally10.Visible = False
        '
        'Tally9
        '
        Me.Tally9.AutoSize = True
        Me.Tally9.Location = New System.Drawing.Point(612, 90)
        Me.Tally9.Name = "Tally9"
        Me.Tally9.Size = New System.Drawing.Size(16, 17)
        Me.Tally9.TabIndex = 21
        Me.Tally9.Text = "0"
        Me.Tally9.Visible = False
        '
        'cmdRollQuad
        '
        Me.cmdRollQuad.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!)
        Me.cmdRollQuad.Location = New System.Drawing.Point(30, 95)
        Me.cmdRollQuad.Name = "cmdRollQuad"
        Me.cmdRollQuad.Size = New System.Drawing.Size(297, 62)
        Me.cmdRollQuad.TabIndex = 25
        Me.cmdRollQuad.Text = "Roll Quad"
        Me.cmdRollQuad.UseVisualStyleBackColor = True
        Me.cmdRollQuad.Visible = False
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!)
        Me.lblScore.Location = New System.Drawing.Point(71, 199)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(184, 46)
        Me.lblScore.TabIndex = 26
        Me.lblScore.Text = "Score: 0"
        '
        'GameScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 455)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.cmdRollQuad)
        Me.Controls.Add(Me.Tally12)
        Me.Controls.Add(Me.Tally11)
        Me.Controls.Add(Me.Tally10)
        Me.Controls.Add(Me.Tally9)
        Me.Controls.Add(Me.tally8)
        Me.Controls.Add(Me.Tally7)
        Me.Controls.Add(Me.tally6)
        Me.Controls.Add(Me.Tally5)
        Me.Controls.Add(Me.tally4)
        Me.Controls.Add(Me.Tally3)
        Me.Controls.Add(Me.Tally2)
        Me.Controls.Add(Me.Tally1)
        Me.Controls.Add(Me.cmdRollDice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GameScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cybo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents cmdRollDice As Windows.Forms.Button
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Friend WithEvents Tally1 As Windows.Forms.Label
    Friend WithEvents Tally2 As Windows.Forms.Label
    Friend WithEvents Tally3 As Windows.Forms.Label
    Friend WithEvents tally4 As Windows.Forms.Label
    Friend WithEvents tally8 As Windows.Forms.Label
    Friend WithEvents Tally7 As Windows.Forms.Label
    Friend WithEvents tally6 As Windows.Forms.Label
    Friend WithEvents Tally5 As Windows.Forms.Label
    Friend WithEvents Tally12 As Windows.Forms.Label
    Friend WithEvents Tally11 As Windows.Forms.Label
    Friend WithEvents Tally10 As Windows.Forms.Label
    Friend WithEvents Tally9 As Windows.Forms.Label
    Friend WithEvents cmdRollQuad As Windows.Forms.Button
    Friend WithEvents lblScore As Windows.Forms.Label
End Class
