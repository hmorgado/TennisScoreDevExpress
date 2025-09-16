using System;
using System.Windows.Forms;

namespace TennisScoreDevExpress
{
  public class Match
  {
    private Jogador jogador1 { get; set; }
    private Jogador jogador2 { get; set; }
    private bool _jogoEmAndamento = true;
    private bool _foiParaTB = false;
    private Jogador _sacador;

    //evento
    public event Action atualizaPlacar;
    public event Action iniciaTB;
    public event Action fimDeJogo;
    //evento

    public Match(Jogador jogador1, Jogador jogador2, int sacador = 1)
    {
      this.jogador1 = jogador1;
      this.jogador2 = jogador2;
      this._sacador = (sacador == 1) ? jogador1 : jogador2;
    }

    public bool Jogador1Sacando() { return _sacador.NumJogador == 1; }
    public bool Jogador2Sacando() { return _sacador.NumJogador == 2; }

    public bool FoiParaTB
    {
      get { return _foiParaTB; }
      set { _foiParaTB = value; }
    }

    public Jogador Vencedor
    {
      get
      {
        Jogador vencedor = null;
        if (!jogador1.Vencedor && !jogador2.Vencedor)
          throw new Exception("Nenhum jogador venceu ainda");
        else
        {
          if (jogador1.Vencedor)
            vencedor = jogador1;
          if (jogador2.Vencedor)
            vencedor = jogador2;
        }
        return vencedor;
      }
    }
    public string gameJogador1()
    {
      return jogador1.Game.ToString();
    }
    public string gameJogador2()
    {
      return jogador2.Game.ToString();
    }
    public string tbPontoJogador1()
    {
      return jogador1.TBPonto.ToString();
    }
    public string tbPontoJogador2()
    {
      return jogador2.TBPonto.ToString();
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
      jogador1.IndicePonto = 3;
      jogador2.IndicePonto = 3;
    }
    public bool JogoEmAndamento { get => _jogoEmAndamento; }
    public bool jogoFinalizado() { return !JogoEmAndamento; }
    private bool placar6a6() { return jogador1.Game == 6 && jogador2.Game == 6; }
    
    private void alternaSacador()
    {
      this._sacador = this._sacador.NumJogador == 1 ? jogador2 : jogador1;
    }
    private void fimGame(Jogador vencedorDoGame)
    {
      jogador1.resetPonto();
      jogador2.resetPonto();
      vencedorDoGame.marcarGame();
      alternaSacador();
      verificaGamesParaTBOuFimSet(vencedorDoGame);
    }
    private void finalizarJogo()
    {
      fimDeJogo?.Invoke();
      _jogoEmAndamento = false;
    }
    private bool placar6a01234ou7a5(Jogador vencedorDoGame)
    {
      // Melhor forma de descobrir quemMarcou e oOutro
      Jogador oOutro = vencedorDoGame.NumJogador == 1 ? jogador2 : jogador1;
      return (vencedorDoGame.Game == 6 && oOutro.Game <= 4) ||
        (vencedorDoGame.Game == 7 && oOutro.Game == 5);
    }
    private void verificaGamesParaTBOuFimSet(Jogador vencedorDoGame)
    {
      if (placar6a01234ou7a5(vencedorDoGame)) { finalizarJogo(); }
      if (placar6a6()) {
        _foiParaTB = true;
        iniciaTB?.Invoke();
      }
    }
    private void verificaFimTB(int numeroDoJogador)
    {
      (Jogador quemMarcou, Jogador oOutro) = encontraMarcadorEAdversario(numeroDoJogador);

      if (quemMarcou.TBPonto >= 7 && oOutro.TBPonto <= 5)
      {
        quemMarcou.Vencedor = true;
        quemMarcou.marcarGame();
        finalizarJogo();
      }
      else
      {
        if (
          // pontos no TB acima de 5-5 e diferença entre pontos é = 2
          (quemMarcou.TBPonto >=5 && oOutro.TBPonto >= 5) &&
          (quemMarcou.TBPonto - oOutro.TBPonto == 2)
        )
        {
          quemMarcou.Vencedor = true;
          quemMarcou.marcarGame();
          finalizarJogo();
        }
      }
    }

    public void jogadorXMarcarTBPonto(int numeroDoJogador)
    {
      Jogador quemMarcou = encontraMarcadorEAdversario(numeroDoJogador).Item1;

      quemMarcou.marcarTbPonto();
      verificaFimTB(numeroDoJogador);
    }

    // Segunda melhor forma de descobrir quemMarcou e oOutro
    // Aqui só temos o int numeroDoJogador que veio do botao do form
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
      (Jogador quemMarcou, Jogador oOutro) = encontraMarcadorEAdversario(numeroDoJogador);

      // 0 15 30 40 vantagem
      // 0 1  2  3     4    
      quemMarcou.marcarPonto();
      if (oOutro.IndicePonto <= 2 && quemMarcou.IndicePonto == 4)
        fimGame(quemMarcou);
      if (oOutro.IndicePonto == 3 && quemMarcou.IndicePonto == 5)
        fimGame(quemMarcou);
      if (oOutro.IndicePonto == 4 && quemMarcou.IndicePonto == 4)
        iguais();
      atualizaPlacar?.Invoke();
    }
  }
}