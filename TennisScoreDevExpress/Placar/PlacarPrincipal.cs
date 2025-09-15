using DevExpress.XtraEditors;
using System;
using TennisScoreDevExpress.Placar;

namespace TennisScoreDevExpress
{
  public partial class PlacarPrincipalForm1 : DevExpress.XtraEditors.XtraForm
  {
    private static Jogador federer = new Jogador("Federer", 1);
    private static Jogador nadal = new Jogador("Nadal", 2);
    private Match match = new Match(federer, nadal);

    public PlacarPrincipalForm1()
    {
      InitializeComponent();

      // chama método atualizaPlacar DESTA CLASSE
      // quando game é vencido com Jogador j (vencedor) como param
      match.atualizaPlacar += atualizaPlacar;
      match.iniciaTB += iniciaTBForm;
      match.fimDeJogo += fimDeJogoForm;
    }

    private void fimDeJogoForm()
    {
      atualizaPlacar();
      new FimDeJogo().Show();
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

      btnPontoJogador1.Enabled = match.jogoEmAndamento();
      btnPontoJogador2.Enabled = match.jogoEmAndamento();

      if (match.jogoFinalizado())
      {
        labelTBJogador1.Text = match.tbPontoJogador1();
        labelTBJogador2.Text = match.tbPontoJogador2();

        labelTBJogador1.Visible = true;
        labelTBJogador2.Visible = true;
      }
    }

    private void btnPonto_Click(object sender, EventArgs e)
    {
      SimpleButton obj = (SimpleButton)sender;
      match.jogadorXMarcarPonto(obj.Name == "btnPontoJogador1" ? 1 : 2);
    }
  }
}
