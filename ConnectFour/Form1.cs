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
    public partial class frmGameboard : Form
    {
        public frmGameboard()
        {
            InitializeComponent();
        }

        private void frmGameboard_Load(object sender, EventArgs e)
        {
            Gameboard newgame = new Gameboard(pnlGameboard);

            newgame.playerSwitch += new Gameboard.CurrentyPlayer(playerUpdate);
            
            newgame.playerWonMsg += new Gameboard.Winner(winner);
            newgame.rowFull += new Gameboard.rowError(error);

            newgame.buildBoard();
            newgame.enterToken();
        }

        void playerUpdate(string s)
        {
            lblPlayer.Text = s;
        }

        void winner(string b)
        {
            lblWinner.Text = b;
        }

        void error(string s)
        {
            lblWinner.Text = s;
        }

    }
}
