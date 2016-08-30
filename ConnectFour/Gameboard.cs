//-------------------------------------
// Author: Joe Velasquez
// Date  : Augest 27 2015
// Desc  : This is the connectFour game, get four in a row horizontally or vertically to win.
//-------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConnectFour
{
    class Gameboard
    {

        private Button[,] gameButton = new Button[7,6];

        private Panel gameBoard;
        /// <summary>
        /// ///////////////////
        /// </summary>

        private int numCols = 7;  //y
        private int numRows = 6; //x
        private int currentPlayer = 1;

        public delegate void CurrentyPlayer(string s);
        public event CurrentyPlayer playerSwitch;

        public delegate void Winner(string s);
        public event Winner playerWonMsg;

        public delegate void rowError(string s);
        public event rowError rowFull;

        public Gameboard() { }

        public Gameboard(Panel board)
        {
            this.gameBoard = board;

        }

        public void enterToken()
        {
            int startTop = 5;
            int startLeft = 35;

            int numCols = 7;

            Button[] insertToken = new Button[numCols];  // create a array that hold button objects

            int i = 0;
            for (int y = 0; y < numCols; y++)
            {
                    if (i < numCols)
                    {
                        insertToken[i] = new Button();
                        insertToken[i].Text = Convert.ToString("Add Token");
                        insertToken[i].BackColor = Color.Yellow;
                        insertToken[i].Size = new Size(90, 30);
                        insertToken[i].Location = new Point(startLeft + (90 * y), startTop);
                        insertToken[i].Tag = i;
                        insertToken[i].Click += new EventHandler(addToken);
                        insertToken[i].FlatStyle = FlatStyle.Flat;
                        gameBoard.Controls.Add(insertToken[i]);
                        i++;
                    }
            }
        }

        //check the current column for any id that = a chip, if a chip is not fouund add a chip to the last row else row -1 = current player chip
        //example... player clicks column 3, onClick = check all rows in column 3 for a player chip id=1or2, 
        //if a chip is found in row 4 then add a chip to row 3 else add chip to the current column's last row ie row 6.
        private void addToken(object sender, EventArgs e)
        {
            Button column = (Button)sender;
            int currentColumn = Convert.ToInt16(column.Tag);
            int currentRowb = 0;
            int previousCell;

            try
            {
                if(checkIfFull() == true)
                {
                    rowFull("GameOver! The board is full." + Environment.NewLine + "Starting a new game");
                    System.Threading.Thread.Sleep(50);
                    resetBoard();
                }
                else
                {
                    rowFull("");

                    for (int currentRow = numRows-1; currentRow >= 0; currentRow--)
                    {
                        int cellValue = Convert.ToInt16(gameButton[currentColumn, currentRow].Tag); //this is the token type 0=empty 1=player1 2=player2
                        if (currentRow != 0) //checks to see if previous row goes below 0
                        {
                            previousCell = currentRow - 1;
                        }
                        else
                        {
                            previousCell = currentRow;
                        }


                        if (cellValue == 0)
                        {
                            player(currentColumn, currentRow);
                            currentRowb = currentRow;
                            break;
                        }
 
                    }
                    if (currentRowb == 0)
                    {
                        rowFull("That Column is full, " + Environment.NewLine + "please try another");
                    }
                    else
                    {
                        if (checkVerticalWin(currentColumn) == true || (checkHorizontal(currentRowb) == true))
                        {
                            
                            playerWonMsg("      Congratulations" + Environment.NewLine + "The Winner is Player " + currentPlayer + "!");
                            
                            resetBoard();
                        }
                        else
                        {
                            playerWonMsg("");
                            switchPlayers();
                        }
                    }
                }

            }
            catch (Exception n)
            {
                MessageBox.Show(Convert.ToString(n));
            }
            

        }

        public void buildBoard() // Creats a dynamic button array 
        {
            int startTop = 40;
            int startLeft = 35;



            //Button[,] slotArray = new Button[numCols , numRows];  // create a array that hold button objects

            // now loop through the array of buttons and add a new button and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                            gameButton[y, x] = new Button();
                            gameButton[y, x].Tag = 0;
                            //gameButton[y, x].Text = Convert.ToString(y+","+x);
                            gameButton[y, x].BackColor = Color.White;
                            gameButton[y, x].Size = new Size(90, 90);
                            gameButton[y, x].Location = new Point(startLeft + (90 * y), startTop + (90 * x));
                            gameButton[y, x].FlatStyle = FlatStyle.Flat;
                        //buttonArray[i].Click += new EventHandler(MyHandler);
                        gameBoard.Controls.Add(gameButton[y,x]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        private void cdraw(Panel board)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            
        }

        private void switchPlayers()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }
            playerSwitch("Player " + currentPlayer); //triggers the playerSwitch event to display the current player's name on the gameboard.
        }

        private void player(int column, int x)
        {
            if(currentPlayer == 1)
            {
                gameButton[column, x].Tag = currentPlayer;
                gameButton[column, x].BackColor = Color.Blue;
                gameButton[column, x].FlatStyle = FlatStyle.Flat;
                    //gameButton[column, x].Text = Convert.ToString(column +"," + x);
            }
            else if(currentPlayer == 2)
            {
                gameButton[column, x].Tag = currentPlayer;
                gameButton[column, x].BackColor = Color.Red;
                gameButton[column, x].FlatStyle = FlatStyle.Flat;
                //gameButton[column, x].Text = Convert.ToString(column + "," + x);
            }

        }

        private bool checkVerticalWin(int curColumn) //checks for a vertical win
        {
            int countThis=0;
            for (int currentRow = 0; currentRow < numRows; currentRow++)
            {
                int cellValue = Convert.ToInt16(gameButton[curColumn, currentRow].Tag);
                if (cellValue == currentPlayer)
                {
                    countThis++;
                    //MessageBox.Show(Convert.ToString("First: Count : "+ countThis + " currentplayer : " + currentPlayer + " cellvalue : " + cellValue));
                    if (countThis == 4)
                    {
                        return true;
                    }
                    
                }
                else if(cellValue != currentPlayer)
                {
                    countThis = 0;
                }

            }
            //MessageBox.Show(Convert.ToString("Third: Count : " + countThis + " currentplayer : " + currentPlayer + " cellvalue : "));
            return false;
        }

        private bool checkHorizontal(int curRow)
        {
            int countThis = 0;
            for (int currentColumn = 0; currentColumn < numCols; currentColumn++)
            {
                int cellValue = Convert.ToInt16(gameButton[currentColumn, curRow].Tag);
                if (cellValue == currentPlayer)
                {
                    countThis++;
                    //MessageBox.Show(Convert.ToString("First: Count : "+ countThis + " currentplayer : " + currentPlayer + " cellvalue : " + cellValue));
                    if (countThis == 4)
                    {
                        return true;
                    }

                }
                else if (cellValue != currentPlayer)
                {
                    countThis = 0;
                }

            }
            return false;
        }

        private void whoWon()
        {

        }


        private bool checkIfFull() //resets the gameboard
        {
            int count = 0;
            int yCount = gameButton.Length;
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    if(Convert.ToInt16(gameButton[y, x].Tag) != 0)
                    {
                        count++;
                    }
                }
  
            }
            if (count == yCount)
            {
                return true;
            }
            return false;
        }

        private void resetBoard() //resets the gameboard
        {
            for (int x = 0; x < numRows; x++)
            {

                for (int y = 0; y < numCols; y++)
                {
                    gameButton[y, x].Tag = 0;
                    gameButton[y, x].BackColor = Color.White;
                    gameButton[y, x].FlatStyle = FlatStyle.Flat;
                }
            }
        }
    }


}
