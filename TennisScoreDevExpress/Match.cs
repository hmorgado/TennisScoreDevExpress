using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisScoreDevExpress
{
  public class Match
  {
    private Jogador jogador1 {  get; set; }
    private Jogador jogador2 {  get; set; }
    private bool _jogoEmAndamento = true;
    public bool foiParaTB = false;
    private Jogador sacador = null;

    //evento
    public event Action atualizaPlacar;
    public event Action iniciaTB;
    public event Action fimDeJogo;
    //evento

    public Match(Jogador jogador1, Jogador jogador2)
    {
      this.jogador1 = jogador1;
      this.jogador2 = jogador2;
    }

    public Jogador vencedor()
    {
      Jogador vencedor = null;
      if (jogador1.vencedor)
        vencedor = jogador1;
      if (jogador2.vencedor)
        vencedor = jogador2;

      return vencedor;
    }
    public string gameJogador1()
    {
      return jogador1.game.ToString();
    }

    public string gameJogador2()
    {
      return jogador2.game.ToString();
    }

    public string tbPontoJogador1()
    {
      return jogador1.tbPonto.ToString();
    }
    public string tbPontoJogador2()
    {
      return jogador2.tbPonto.ToString();
    }
    public string pontoJogador1()
    {
      return jogador1.mostrarPonto();
    }
    public string pontoJogador2()
    {
      return jogador2.mostrarPonto();
    }
    private void iguais()
    {
      jogador1.indicePonto = 3;
      jogador2.indicePonto = 3;
    }
    public bool jogoEmAndamento()
    {
      return _jogoEmAndamento;
    }
    public bool jogoFinalizado()
    {
      return !jogoEmAndamento();
    }
    private bool placar6a6()
    {
      return jogador1.game == 6 && jogador2.game == 6;
    }
    private void fimGame(Jogador vencedorDoGame)
    {
      jogador1.resetPonto();
      jogador2.resetPonto();
      vencedorDoGame.marcarGame();
      verificaGamesParaTBOuFimSet(vencedorDoGame);
    }

    private void finalizarJogo()
    {
      fimDeJogo?.Invoke();
      _jogoEmAndamento = false;
    }
    
    private void verificaGamesParaTBOuFimSet(Jogador vencedorDoGame)
    {
      Jogador oOutro = vencedorDoGame.numJogador == 1 ? jogador2 : jogador1;

      if (vencedorDoGame.game == 6 && oOutro.game <= 4)
      {
        finalizarJogo();
      }
      if (placar6a6()) {
        foiParaTB = true;
        iniciaTB?.Invoke();
      }
    }

    private void verificaFimTB(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;
      (Jogador, Jogador) jogadores = encontraMarcadorEAdversario(numeroDoJogador);
      quemMarcou = jogadores.Item1;
      oOutro = jogadores.Item2;

      if (quemMarcou.tbPonto >= 7 && oOutro.tbPonto <= 5)
      {
        quemMarcou.vencedor = true;
        quemMarcou.marcarGame();
        finalizarJogo();
      }
      else
      {
        if (
          (quemMarcou.tbPonto >=5 && oOutro.tbPonto >= 5) &&
          (quemMarcou.tbPonto - oOutro.tbPonto == 2)
        )
        {
          quemMarcou.vencedor = true;
          quemMarcou.marcarGame();
          finalizarJogo();
        }
      }
    }

    public void jogadorXMarcarTBPonto(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;
      (Jogador, Jogador) jogadores = encontraMarcadorEAdversario(numeroDoJogador);
      quemMarcou = jogadores.Item1;
      oOutro = jogadores.Item2;

      quemMarcou.marcarTbPonto();
      verificaFimTB(numeroDoJogador);
    }
    private (Jogador, Jogador) encontraMarcadorEAdversario(int numeroDoJogador)
    {
      // faz assign de quem marcou ponto baseado no número do jogador (1 esquerda, 2 direita)

      Jogador quemMarcou = null;
      Jogador oOutro = null;

      switch (numeroDoJogador)
      {
        case 1:
          quemMarcou = jogador1;
          oOutro = jogador2;
          break;
        case 2:
          quemMarcou = jogador2;
          oOutro = jogador1;
          break;
        default:
          MessageBox.Show($"Numero do jogador inválido {numeroDoJogador}");
          break;
      }
      return (quemMarcou, oOutro);
    }

    public void jogadorXMarcarPonto(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;
      (Jogador, Jogador) jogadores = encontraMarcadorEAdversario(numeroDoJogador);
      quemMarcou = jogadores.Item1;
      oOutro = jogadores.Item2;

      // 0 15 30 40 vantagem
      // 0 1  2  3     4    
      quemMarcou.marcarPonto();
      if (oOutro.indicePonto <= 2 && quemMarcou.indicePonto == 4)
        fimGame(quemMarcou);
      if (oOutro.indicePonto == 3 && quemMarcou.indicePonto == 5)
        fimGame(quemMarcou);
      if (oOutro.indicePonto == 4 && quemMarcou.indicePonto == 4)
        iguais();
      atualizaPlacar?.Invoke();
    }
  }
}