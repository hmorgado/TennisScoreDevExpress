using DevExpress.XtraEditors;
using System;
using TennisScoreDevExpress.Placar;

namespace TennisScoreDevExpress
{
  public partial class PlacarPrincipalForm1 : DevExpress.XtraEditors.XtraForm
  {
    private static Jogador j1 = new Jogador("Heitor", 1);
    private static Jogador j2 = new Jogador("João", 2);
    private Match match = new Match(j1, j2);

    public PlacarPrincipalForm1()
    {
      InitializeComponent();

      // chama método atualizaPlacar DESTA CLASSE
      // quando game é vencido com Jogador j (vencedor) como param
      atualizaPlacar();
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
      labelJogador1Nome.Text = j1.Nome;
      labelJogador2Nome.Text = j2.Nome;
      
      // jog 1
      labelGameFederer.Text = match.gameJogador1();
      labelPontoFederer.Text = match.pontoJogador1();

      // jog 2
      labelPontoNadal.Text = match.pontoJogador2();
      labelGameNadal.Text = match.gameJogador2();

      btnPontoJogador1.Enabled = match.JogoEmAndamento;
      btnPontoJogador2.Enabled = match.JogoEmAndamento;

      if (match.jogoFinalizado() && match.getFoiParaTB())
      {
        labelTBJogador1.Text = match.tbPontoJogador1();
        labelTBJogador2.Text = match.tbPontoJogador2();

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
