using DevExpress.XtraEditors;
using System;
using TennisScoreDevExpress.Placar;

namespace TennisScoreDevExpress
{
  public partial class PlacarPrincipalForm1 : DevExpress.XtraEditors.XtraForm
  {
    private static Jogador j1 = new Jogador("Heitor", 1);
    private static Jogador j2 = new Jogador("João", 2);
    private Match match = new Match(j1, j2, sacador: 2);

    public PlacarPrincipalForm1()
    {
      InitializeComponent();

      // chama método atualizaPlacar DESTA CLASSE
      // quando game é vencido com Jogador j (vencedor) como param
      atualizaPlacar();
      labelJogador1Nome.Text = j1.Nome;
      labelJogador2Nome.Text = j2.Nome;

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
      labelGameJogador1.Text = match.gameJogador1();
      labelPontoJogador1.Text = match.pontoJogador1();
      
      // jog 2
      labelPontoJogador2.Text = match.pontoJogador2();
      labelGameJogador2.Text = match.gameJogador2();

      labelTotalPontosJogador1.Text = match.Jogador1TotalPontos;
      labelTotalPontosJogador2.Text = match.Jogador2TotalPontos;

      btnPontoJogador1.Enabled = match.JogoEmAndamento;
      btnPontoJogador2.Enabled = match.JogoEmAndamento;

      labelSacandoJogador1.Visible = match.Jogador1Sacando();
      labelSacandoJogador2.Visible = match.Jogador2Sacando();
      
      if (match.jogoFinalizado() && match.FoiParaTB)
      {
        labelTBJogador1.Text = match.tbPontoJogador1();
        labelTBJogador2.Text = match.tbPontoJogador2();

        labelSacandoJogador1.Visible = false;
        labelSacandoJogador2.Visible = false;

        labelTBJogador1.Visible = true;
        labelTBJogador2.Visible = true;
      }
    }

    private void btnPonto_Click(object sender, EventArgs e)
    {
      //TODO passar jogador que marcou o ponto aqui ao invés do número
      // ou passar o número do jogador através da propriedade numjogador
      SimpleButton obj = (SimpleButton)sender;
      match.jogadorXMarcarPonto(obj.Name == "btnPontoJogador1" ? 1 : 2);
    }
  }
}
