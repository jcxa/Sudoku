using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox82.Text = "40";                  // Initialize the number of clues textbox.
            iTotalMistakes = 0;                     // Initialize the total mistakes counter.
            label25.Text = "# of mistakes: 0";
            Generate();
        }

        int iTotalMistakes = 0;

        // Variable matrix is only used to display the hypotheses values, so it can help user playing the game. It is displayed below the table.
        string[,,] matrix = new string[9, 9, 9];    // Column, Row, Depth

        public void InitializeMatrix()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        matrix[i, j, k] = (k + 1).ToString();
                    }
                }
            }
        }

        // Variable table holds the Sudoku correct values, following the classic game rules: 1 to 9 on each column, on each row, and on each cell, without repetitions.
        string[,] table = new string[9, 9];         // Column, Row

        public void InitializeTable()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    table[i, j] = "";
                }
            }
        }

        public void ClearFormTextBoxes()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)c;

                    if (tb.TabIndex >= 1 && tb.TabIndex <= 81)
                    {
                        tb.Text = "";
                        tb.ReadOnly = false;
                        tb.BackColor = Color.White;
                    }
                }
            }

            iTotalMistakes = 0;
            label25.Text = "# of mistakes: 0";
        }

        public List<string> RetrieveTableColumnValues(int iColumn)
        {
            List<string> listValues = new List<string>();

            for (int j = 0; j < 9; j++)
            {
                if (table[iColumn, j] != "")
                {
                    listValues.Add(table[iColumn, j]);
                }
            }

            return listValues;
        }

        public List<string> RetrieveTableRowValues(int iRow)
        {
            List<string> listValues = new List<string>();

            for (int i = 0; i < 9; i++)
            {
                if (table[i, iRow] != "")
                {
                    listValues.Add(table[i, iRow]);
                }
            }

            return listValues;
        }

        /* 9 cells are set in the table. Each cell is a predefined set of 9 close values (a square region).
         * For instance, cell 2 is the set between columns 4 and 6 and between rows 1 and 3.
         *    123  456  789 
         * 1 [   ][   ][   ]
         * 2 [ 1 ][ 2 ][ 3 ]
         * 3 [   ][   ][   ]
         * 
         * 4 [   ][   ][   ]
         * 5 [ 4 ][ 5 ][ 6 ]
         * 6 [   ][   ][   ]
         * 
         * 7 [   ][   ][   ]
         * 8 [ 7 ][ 8 ][ 9 ]
         * 9 [   ][   ][   ]
        */
        public List<string> RetrieveCell1Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell2Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell3Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell4Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell5Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell6Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell7Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell8Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveCell9Values()
        {
            List<string> listValues = new List<string>();

            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (table[i, j] != "")
                    {
                        listValues.Add(table[i, j]);
                    }
                }
            }

            return listValues;
        }

        public List<string> RetrieveTableCellValues(int iColumn, int iRow)
        {
            if (iColumn >= 0 && iColumn < 3)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    return RetrieveCell1Values();
                }

                if (iRow >= 3 && iRow < 6)
                {
                    return RetrieveCell4Values();
                }

                if (iRow >= 6 && iRow < 9)
                {
                    return RetrieveCell7Values();
                }
            }

            if (iColumn >= 3 && iColumn < 6)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    return RetrieveCell2Values();
                }

                if (iRow >= 3 && iRow < 6)
                {
                    return RetrieveCell5Values();
                }

                if (iRow >= 6 && iRow < 9)
                {
                    return RetrieveCell8Values();
                }
            }

            if (iColumn >= 6 && iColumn < 9)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    return RetrieveCell3Values();
                }

                if (iRow >= 3 && iRow < 6)
                {
                    return RetrieveCell6Values();
                }

                if (iRow >= 6 && iRow < 9)
                {
                    return RetrieveCell9Values();
                }
            }

            return null;
        }

        public void ClearTableColumn(int iColumn)
        {
            for (int j = 0; j < 9; j++)
            {
                table[iColumn, j] = "";
            }
        }

        public string DisplayTableForDebug()
        {
            string sDisplayTable = "";

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (table[i, j].Trim() != "")
                    {
                        sDisplayTable += table[i, j] + " ";
                    }
                    else
                    {
                        sDisplayTable += " " + " ";
                    }
                }

                sDisplayTable += "|";
            }

            return sDisplayTable;
        }

        public string DisplayTable()
        {
            string sDisplayTable = "";

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (table[i, j].Trim() != "")
                    {
                        sDisplayTable += table[i, j] + ", ";
                    }
                }

                sDisplayTable += System.Environment.NewLine;
            }

            return sDisplayTable;
        }

        public string DisplayMatrixForDebug()
        {
            string sDisplayMatrix = "";

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (matrix[i, j, k].Trim() != "")
                        {
                            sDisplayMatrix += matrix[i, j, k] + " ";
                        }
                        else
                        {
                            sDisplayMatrix += " " + " ";
                        }
                    }
                }

                sDisplayMatrix += "|";
            }

            return sDisplayMatrix;
        }

        public string RefreshMatrixByRows()
        {
            string sDisplayMatrix = "";

            for (int j = 0; j < 9; j++)
            {
                sDisplayMatrix += "[row " + (j + 1).ToString() + "] ";

                for (int i = 0; i < 9; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (matrix[i, j, k].Trim() != "")
                        {
                            sDisplayMatrix += matrix[i, j, k] + ",";
                        }
                        else
                        {
                            sDisplayMatrix += " " + ",";
                        }
                    }

                    sDisplayMatrix += "   ";
                }

                sDisplayMatrix += System.Environment.NewLine;
            }

            return sDisplayMatrix;
        }

        public string RefreshMatrixByColumns()
        {
            string sDisplayMatrix = "";

            for (int i = 0; i < 9; i++)
            {
                sDisplayMatrix += "[column " + (i + 1).ToString() + "] ";

                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (matrix[i, j, k].Trim() != "")
                        {
                            sDisplayMatrix += matrix[i, j, k] + ",";
                        }
                        else
                        {
                            sDisplayMatrix += " " + ",";
                        }
                    }

                    sDisplayMatrix += "   ";
                }

                sDisplayMatrix += System.Environment.NewLine;
            }

            return sDisplayMatrix;
        }

        // Generate the Sudoku table values following the game rules.
        public void GenerateSudokuTable()
        {
            Random random = new Random();

            int iTotalRowResets = 0;

            // i = columns
            for (int i = 0; i < 9; i++)
            {
                int iRowIterations = 0;

                // j = rows
                for (int j = 0; j < 9; j++)
                {
                    List<string> tableColumnValues = RetrieveTableColumnValues(i);      // This list holds all the values already set for column i
                    List<string> tableRowValues = RetrieveTableRowValues(j);            // This list holds all the values already set for row j
                    List<string> tableCellValues = RetrieveTableCellValues(i, j);       // This list holds all the values already set for cell(i,j)

                    int r = 0;

                    do
                    {
                        r = random.Next(1, 10);     // r = random integer between 1 and 9.

                        iRowIterations++;           // Limits the number of row iterations to avoid infinite random loops.
                    }
                    while ((tableColumnValues.Contains(r.ToString()) || tableRowValues.Contains(r.ToString()) || (tableCellValues != null && tableCellValues.Contains(r.ToString()))) && iRowIterations < 100);

                    if (iRowIterations == 100)
                    {
                        iTotalRowResets++;          // Limits the number of row iterations to avoid infinite row loops.

                        if (iTotalRowResets == 100)
                        {
                            iTotalRowResets = 0;
                            InitializeTable();
                            i = -1;
                        }
                        else
                        {
                            iRowIterations = 0;
                            ClearTableColumn(i);

                            if (i > 0)
                            {
                                i--;
                            }
                        }

                        break;
                    }

                    table[i, j] = r.ToString();     // Finally sets an integer value for each column i, row j, avoiding any repetition on columns, rows and cells.
                }
            }
        }

        public void DisplayHint(int iTabIndex)
        {
            int iColumn = -1;
            int iRow = -1;
            RetrieveColumnAndRowByTextBoxIndex(iTabIndex, out iColumn, out iRow);

            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)c;

                    if (tb.TabIndex == iTabIndex)
                    {
                        tb.Text = table[iColumn, iRow];
                        ProcessUserInput(iColumn, iRow, tb);
                    }
                }
            }
        }

        public void DisplayHints()
        {
            string sNumberOfHints = textBox82.Text;

            if (sNumberOfHints.Trim() == "")
            {
                textBox82.Text = "40";
            }

            int iNumberOfHints = Convert.ToInt32(textBox82.Text);

            Random random = new Random();
            List<int> list = new List<int>();

            while (list.Count < iNumberOfHints)
            {
                int r = random.Next(1, 82);

                if (!list.Contains(r))
                {
                    list.Add(r);
                }
            }

            foreach (int n in list)
            {
                DisplayHint(n);
            }
        }

        private void Generate()
        {
            InitializeMatrix();
            InitializeTable();
            ClearFormTextBoxes();

            GenerateSudokuTable();
            DisplayHints();

            label19.Text = RefreshMatrixByRows();       // Refresh hypotheses matrix (by rows).
            label24.Text = RefreshMatrixByColumns();    // Refresh hypotheses matrix (by columns).
        }

        // New Sudoku button.
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want a new Sudoku?", "New Sudoku", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Generate();
            }
        }

        private void ClearValueFromMatrixColumn(string sValue, int iColumn)
        {
            for (int j = 0; j < 9; j++)
            {
                matrix[iColumn, j, Convert.ToInt32(sValue) - 1] = "";
            }
        }

        private void ClearValueFromMatrixRow(string sValue, int iRow)
        {
            for (int i = 0; i < 9; i++)
            {
                matrix[i, iRow, Convert.ToInt32(sValue) - 1] = "";
            }
        }

        private void ClearValueFromMatrixCell1(string sValue)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell2(string sValue)
        {
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell3(string sValue)
        {
            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell4(string sValue)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell5(string sValue)
        {
            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell6(string sValue)
        {
            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell7(string sValue)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell8(string sValue)
        {
            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell9(string sValue)
        {
            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    matrix[i, j, Convert.ToInt32(sValue) - 1] = "";
                }
            }
        }

        private void ClearValueFromMatrixCell(string sValue, int iColumn, int iRow)
        {
            if (iColumn >= 0 && iColumn < 3)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    ClearValueFromMatrixCell1(sValue);
                }

                if (iRow >= 3 && iRow < 6)
                {
                    ClearValueFromMatrixCell4(sValue);
                }

                if (iRow >= 6 && iRow < 9)
                {
                    ClearValueFromMatrixCell7(sValue);
                }
            }

            if (iColumn >= 3 && iColumn < 6)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    ClearValueFromMatrixCell2(sValue);
                }

                if (iRow >= 3 && iRow < 6)
                {
                    ClearValueFromMatrixCell5(sValue);
                }

                if (iRow >= 6 && iRow < 9)
                {
                    ClearValueFromMatrixCell8(sValue);
                }
            }

            if (iColumn >= 6 && iColumn < 9)
            {
                if (iRow >= 0 && iRow < 3)
                {
                    ClearValueFromMatrixCell3(sValue);
                }

                if (iRow >= 3 && iRow < 6)
                {
                    ClearValueFromMatrixCell6(sValue);
                }

                if (iRow >= 6 && iRow < 9)
                {
                    ClearValueFromMatrixCell9(sValue);
                }
            }
        }

        private void CheckIfGameEnded()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)c;

                    if (tb.TabIndex >= 1 && tb.TabIndex <= 81 && tb.Text.Trim() == "")
                    {
                        return;
                    }
                }
            }

            DialogResult dialogResult = MessageBox.Show("Congratulations! # of mistakes: " + iTotalMistakes.ToString(), "Game over", MessageBoxButtons.OK);
        }

        private void ProcessUserInput(int iColumn, int iRow, TextBox tb)
        {
            if (table[iColumn, iRow] == null || tb.Text.Trim() == "")
            {
                return;
            }

            if (table[iColumn, iRow] != tb.Text)
            {
                tb.Text = "";
                iTotalMistakes++;
                label25.Text = "# of mistakes: " + iTotalMistakes.ToString();
            }
            else
            {
                tb.ReadOnly = true;
                tb.BackColor = Color.FromArgb(240, 240, 240);       // gray.

                ClearValueFromMatrixColumn(tb.Text, iColumn);
                ClearValueFromMatrixRow(tb.Text, iRow);
                ClearValueFromMatrixCell(tb.Text, iColumn, iRow);
            }

            label19.Text = RefreshMatrixByRows();       // Refresh hypotheses matrix (by rows).
            label24.Text = RefreshMatrixByColumns();    // Refresh hypotheses matrix (by columns).

            CheckIfGameEnded();
        }

        private void RetrieveColumnAndRowByTextBoxIndex(int iTabIndex, out int iColumn, out int iRow)
        {
            iColumn = -1;
            iRow = -1;

            switch (iTabIndex)
            {
                case 1:
                    iColumn = 0;
                    iRow = 0;
                    return;
                case 2:
                    iColumn = 1;
                    iRow = 0;
                    return;
                case 3:
                    iColumn = 2;
                    iRow = 0;
                    return;
                case 4:
                    iColumn = 3;
                    iRow = 0;
                    return;
                case 5:
                    iColumn = 4;
                    iRow = 0;
                    return;
                case 6:
                    iColumn = 5;
                    iRow = 0;
                    return;
                case 7:
                    iColumn = 6;
                    iRow = 0;
                    return;
                case 8:
                    iColumn = 7;
                    iRow = 0;
                    return;
                case 9:
                    iColumn = 8;
                    iRow = 0;
                    return;

                case 10:
                    iColumn = 0;
                    iRow = 1;
                    return;
                case 11:
                    iColumn = 1;
                    iRow = 1;
                    return;
                case 12:
                    iColumn = 2;
                    iRow = 1;
                    return;
                case 13:
                    iColumn = 3;
                    iRow = 1;
                    return;
                case 14:
                    iColumn = 4;
                    iRow = 1;
                    return;
                case 15:
                    iColumn = 5;
                    iRow = 1;
                    return;
                case 16:
                    iColumn = 6;
                    iRow = 1;
                    return;
                case 17:
                    iColumn = 7;
                    iRow = 1;
                    return;
                case 18:
                    iColumn = 8;
                    iRow = 1;
                    return;

                case 19:
                    iColumn = 0;
                    iRow = 2;
                    return;
                case 20:
                    iColumn = 1;
                    iRow = 2;
                    return;
                case 21:
                    iColumn = 2;
                    iRow = 2;
                    return;
                case 22:
                    iColumn = 3;
                    iRow = 2;
                    return;
                case 23:
                    iColumn = 4;
                    iRow = 2;
                    return;
                case 24:
                    iColumn = 5;
                    iRow = 2;
                    return;
                case 25:
                    iColumn = 6;
                    iRow = 2;
                    return;
                case 26:
                    iColumn = 7;
                    iRow = 2;
                    return;
                case 27:
                    iColumn = 8;
                    iRow = 2;
                    return;

                case 28:
                    iColumn = 0;
                    iRow = 3;
                    return;
                case 29:
                    iColumn = 1;
                    iRow = 3;
                    return;
                case 30:
                    iColumn = 2;
                    iRow = 3;
                    return;
                case 31:
                    iColumn = 3;
                    iRow = 3;
                    return;
                case 32:
                    iColumn = 4;
                    iRow = 3;
                    return;
                case 33:
                    iColumn = 5;
                    iRow = 3;
                    return;
                case 34:
                    iColumn = 6;
                    iRow = 3;
                    return;
                case 35:
                    iColumn = 7;
                    iRow = 3;
                    return;
                case 36:
                    iColumn = 8;
                    iRow = 3;
                    return;

                case 37:
                    iColumn = 0;
                    iRow = 4;
                    return;
                case 38:
                    iColumn = 1;
                    iRow = 4;
                    return;
                case 39:
                    iColumn = 2;
                    iRow = 4;
                    return;
                case 40:
                    iColumn = 3;
                    iRow = 4;
                    return;
                case 41:
                    iColumn = 4;
                    iRow = 4;
                    return;
                case 42:
                    iColumn = 5;
                    iRow = 4;
                    return;
                case 43:
                    iColumn = 6;
                    iRow = 4;
                    return;
                case 44:
                    iColumn = 7;
                    iRow = 4;
                    return;
                case 45:
                    iColumn = 8;
                    iRow = 4;
                    return;

                case 46:
                    iColumn = 0;
                    iRow = 5;
                    return;
                case 47:
                    iColumn = 1;
                    iRow = 5;
                    return;
                case 48:
                    iColumn = 2;
                    iRow = 5;
                    return;
                case 49:
                    iColumn = 3;
                    iRow = 5;
                    return;
                case 50:
                    iColumn = 4;
                    iRow = 5;
                    return;
                case 51:
                    iColumn = 5;
                    iRow = 5;
                    return;
                case 52:
                    iColumn = 6;
                    iRow = 5;
                    return;
                case 53:
                    iColumn = 7;
                    iRow = 5;
                    return;
                case 54:
                    iColumn = 8;
                    iRow = 5;
                    return;

                case 55:
                    iColumn = 0;
                    iRow = 6;
                    return;
                case 56:
                    iColumn = 1;
                    iRow = 6;
                    return;
                case 57:
                    iColumn = 2;
                    iRow = 6;
                    return;
                case 58:
                    iColumn = 3;
                    iRow = 6;
                    return;
                case 59:
                    iColumn = 4;
                    iRow = 6;
                    return;
                case 60:
                    iColumn = 5;
                    iRow = 6;
                    return;
                case 61:
                    iColumn = 6;
                    iRow = 6;
                    return;
                case 62:
                    iColumn = 7;
                    iRow = 6;
                    return;
                case 63:
                    iColumn = 8;
                    iRow = 6;
                    return;

                case 64:
                    iColumn = 0;
                    iRow = 7;
                    return;
                case 65:
                    iColumn = 1;
                    iRow = 7;
                    return;
                case 66:
                    iColumn = 2;
                    iRow = 7;
                    return;
                case 67:
                    iColumn = 3;
                    iRow = 7;
                    return;
                case 68:
                    iColumn = 4;
                    iRow = 7;
                    return;
                case 69:
                    iColumn = 5;
                    iRow = 7;
                    return;
                case 70:
                    iColumn = 6;
                    iRow = 7;
                    return;
                case 71:
                    iColumn = 7;
                    iRow = 7;
                    return;
                case 72:
                    iColumn = 8;
                    iRow = 7;
                    return;

                case 73:
                    iColumn = 0;
                    iRow = 8;
                    return;
                case 74:
                    iColumn = 1;
                    iRow = 8;
                    return;
                case 75:
                    iColumn = 2;
                    iRow = 8;
                    return;
                case 76:
                    iColumn = 3;
                    iRow = 8;
                    return;
                case 77:
                    iColumn = 4;
                    iRow = 8;
                    return;
                case 78:
                    iColumn = 5;
                    iRow = 8;
                    return;
                case 79:
                    iColumn = 6;
                    iRow = 8;
                    return;
                case 80:
                    iColumn = 7;
                    iRow = 8;
                    return;
                case 81:
                    iColumn = 8;
                    iRow = 8;
                    return;

                default:
                    iColumn = -1;
                    iRow = -1;
                    return;
            }

        }

        // TextBoxes from 1 to 81: user game table.
        private void textBox1_81TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int iColumn = -1;
            int iRow = -1;
            RetrieveColumnAndRowByTextBoxIndex(tb.TabIndex, out iColumn, out iRow);
            ProcessUserInput(iColumn, iRow, tb);
        }

        private void textBox1_81Click(object sender, EventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;

            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)c;

                    if (tb.TabIndex >= 1 && tb.TabIndex <= 81)
                    {
                        if (currentTextBox.Text.Trim() == "")
                        {
                            tb.BackColor = tb.Text.Trim() == "" ? Color.White : Color.FromArgb(240, 240, 240);
                        }
                        else
                        {
                            if (tb.Text == currentTextBox.Text)
                            {
                                tb.BackColor = tb.BackColor == Color.Yellow ? Color.FromArgb(240, 240, 240) : Color.Yellow;
                            }
                            else
                            {
                                tb.BackColor = tb.Text.Trim() == "" ? Color.White : Color.FromArgb(240, 240, 240);
                            }
                        }
                    }
                }
            }
        }

        // TextBox 82: clues.
        private void textBox82_TextChanged(object sender, EventArgs e)
        {
            if (textBox82.Text.Trim() == "")
            {
                textBox82.Text = "0";
            }

            try
            {
                int iNumberOfHints = Convert.ToInt32(textBox82.Text);

                if (iNumberOfHints > 81)
                {
                    textBox82.Text = "81";
                }
            }
            catch
            { }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 19)                            // KeyChar 19 = Ctrl+S
            {
                if (label20.Text.Trim() == "")
                {
                    label22.Text = "Solution Table:";
                    label20.Text = DisplayTable();          // Display solution (debug purposes!)
                }
                else
                {
                    label22.Text = "";
                    label20.Text = "";
                }
            }
        }
    }
}
