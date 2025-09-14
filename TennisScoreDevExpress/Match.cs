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

    //evento
    public event Action atualizaPlacar;
    public event Action iniciaTB;
    //evento

    public Match(
      Jogador jogador1,
      Jogador jogador2
    )
    {
      this.jogador1 = jogador1;
      this.jogador2 = jogador2;
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
    private void fimGame(Jogador j)
    {
      jogador1.resetPonto();
      jogador2.resetPonto();
      j.marcarGame();
      verificaGamesParaTB();
    }

    private void iguais()
    {
      jogador1.indicePonto = 3;
      jogador2.indicePonto = 3;
    }

    private void verificaGamesParaTB()
    {
       if (jogador1.game == 6 && jogador2.game == 6) iniciaTB?.Invoke();
    }

    private void verificaFimTB(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;

      // faz assign de quem marcou ponto baseado no número do jogador (1 esquerda, 2 direita)
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

      if (quemMarcou.tbPonto >= 7 && oOutro.tbPonto <= 5)
      {
        MessageBox.Show($"Fim! vencedor {quemMarcou.name}");
        // TODO
        // 1: atualizarTBPlacar antes de mostrar janela de quem ganhou
        // 2: quando clicar ok no msgBox do vencedor, fechar msgbox e TBplacarForm
        //  e voltar para PlacarPrincipal mostrando placar do TB de alguma forma
        // 3: possibilitar ganhar de 7 5
        // 4: mostrar sacador
      }
      else
      {
        if (
          (quemMarcou.tbPonto >=5 && oOutro.tbPonto >= 5) &&
          (quemMarcou.tbPonto - oOutro.tbPonto == 2)
        )
        {
          MessageBox.Show($"Fim! ******** vencedor {quemMarcou.name}");
        }
      }
    }

    public void jogadorXMarcarTBPonto(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;

      // faz assign de quem marcou ponto baseado no número do jogador (1 esquerda, 2 direita)
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

      quemMarcou.marcarTbPonto();
      verificaFimTB(numeroDoJogador);
    }
    public void jogadorXMarcarPonto(int numeroDoJogador)
    {
      Jogador quemMarcou = null;
      Jogador oOutro = null;

      // faz assign de quem marcou ponto baseado no número do jogador (1 esquerda, 2 direita)
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