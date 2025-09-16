using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  public class Jogador : Pessoa
  {
    private readonly int _numJogador;
    private bool _vencedor = false;

    private int _TBPonto;
    private int _indicePonto = 4;
    private int _game = 4;

    private string[] _pontos = { "0", "15", "30", "40", "vantagem" };

    public Jogador(string nome, int numJogador) : base(nome)
    {
      this._indicePonto = 0;
      this._numJogador = numJogador;
    }

    public bool Vencedor { 
      get => _vencedor;
      set => _vencedor = value;
    }
    public int NumJogador { get => this._numJogador; }

    public string Nome { get => base.Name; }

    public int TBPonto { get => _TBPonto; }
    
    public int IndicePonto {
      get => _indicePonto;
      set => _indicePonto = value;
    }

    public int Game { get => _game; }
    public void marcarPonto() { this._indicePonto++; }
    public void marcarGame(){ this._game++; }
    public void marcarTbPonto() { this._TBPonto++; }
    public string mostrarPonto() { return this._pontos[this._indicePonto]; }
    public void resetPonto() { this._indicePonto = 0; }
  }
}
