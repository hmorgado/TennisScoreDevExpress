using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  
  // TODO atualisar versão do dotnet para 10+ e criar método construtor
  // para struct
  struct Statistics
  {
    public int totalDePontos;
    public int totalAces;
  }

  public class Jogador : Pessoa
  {
    private readonly int _numJogador;
    private bool _vencedor = false;
    private int _TBPonto;
    private int _indicePonto = 0;
    private int _game = 0;
    private readonly string[] _pontos = { "0", "15", "30", "40", "vantagem" };
    private Statistics stats;

    public Jogador(string nome, int numJogador) : base(nome)
    {
      this._indicePonto = 0;
      this._numJogador = numJogador;
      stats.totalDePontos = 0;

      if (true) // troque para true para iniciar o jogo com games e pontos
      {
        _indicePonto = 3;
        _game = 5;
      }
    }
    public bool Vencedor { 
      get => _vencedor;
      set => _vencedor = value;
    }

    public string TotalDePontos { get => stats.totalDePontos.ToString(); }
    public int NumJogador { get => this._numJogador; }
    public string Nome { get => base.Name; }
    public int TBPonto { get => _TBPonto; }
    public int IndicePonto { get => _indicePonto; }
    public void voltarPara40() { this._indicePonto = 3; }
    public int Game { get => _game; }
    public void marcarPonto() {
      stats.totalDePontos++;
      this._indicePonto++;
    }
    public void marcarGame(){ this._game++; }
    public void marcarTbPonto() {
      stats.totalDePontos++;
      this._TBPonto++;
    }
    public string mostrarPonto() { return this._pontos[this._indicePonto]; }
    public void resetPonto() { this._indicePonto = 0; }
  }
}
