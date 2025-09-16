using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisScoreDevExpress.Placar
{
  public partial class FormPlacarTieBreak : Form
  {
    Match match;
    public FormPlacarTieBreak(Match match)
    {
      InitializeComponent();

      this.match = match;
      match.fimDeJogo += atualizaTBPlacar;
    }
    
    private void atualizaTBPlacar()
    {
      labelTBJogador1.Text = match.tbPontoJogador1();
      labelTBJogador2.Text = match.tbPontoJogador2();

      btnPontoTBJogador1.Enabled = match.JogoEmAndamento;
      btnPontoTBJogador2.Enabled = match.JogoEmAndamento;

      btnTBFechar.Visible = match.jogoFinalizado();
    }

    private void btnPontoTB_Click(object sender, EventArgs e)
    {
      SimpleButton obj = (SimpleButton)sender;
      match.jogadorXMarcarTBPonto(obj.Name == "btnPontoTBJogador1" ? 1 : 2);
      atualizaTBPlacar();
    }

    private void btnTBFechar_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
