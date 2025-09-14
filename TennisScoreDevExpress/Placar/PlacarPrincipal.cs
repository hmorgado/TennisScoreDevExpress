using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using TennisScoreDevExpress.Placar;

namespace TennisScoreDevExpress
{
  public partial class PlacarPrincipalForm1 : DevExpress.XtraEditors.XtraForm
  {
    private static Jogador federer = new Jogador("Federer");
    private static Jogador nadal = new Jogador("Nadal");
    private Match match = new Match(federer, nadal);

    public PlacarPrincipalForm1()
    {
      InitializeComponent();

      // chama método atualizaPlacar DESTA CLASSE
      // quando game é vencido com Jogador j (vencedor) como param
      match.atualizaPlacar += atualizaPlacar;
      match.iniciaTB += iniciaTBForm;
    }

    private void iniciaTBForm()
    {
      atualizaPlacar();
      FormPlacarTieBreak formPlacarTieBreak = new FormPlacarTieBreak(match);
      formPlacarTieBreak.ShowDialog();
    }

    private void atualizaPlacar()
    {
      // jog 1
      labelGameFederer.Text = match.gameJogador1();
      labelPontoFederer.Text = match.pontoJogador1();

      // jog 2
      labelPontoNadal.Text = match.pontoJogador2();
      labelGameNadal.Text = match.gameJogador2();
    }

    private void btnPonto_Click(object sender, EventArgs e)
    {
      SimpleButton obj = (SimpleButton)sender;
      match.jogadorXMarcarPonto(obj.Name == "btnPontoJogador1" ? 1 : 2);
    }
  }
}
