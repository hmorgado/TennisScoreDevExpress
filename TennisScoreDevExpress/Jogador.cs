using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  public class Jogador : Pessoa
  {
    private int _numJogador;
    public bool vencedor = false;

    private int _TBPonto;
    private int _indicePonto = 4;
    private int _game = 4;

    string[] pontos = { "0", "15", "30", "40", "vantagem" };

    public Jogador(string nome, int numJogador) : base(nome)
    {
      this._indicePonto = 0;
      this._numJogador = numJogador;
    }
    public int NumJogador { get => this._numJogador; }

    public string Nome { get => base.Name; }

    public int GetTBPonto()
    {
      return this._TBPonto;
    }
    public int GetIndicePonto()
    {
      return _indicePonto;
    }
    public void SetIndicePonto(int i)
    {
      _indicePonto = i;
    }
    public int Game
    {
      get => _game;
    }
    public void marcarPonto() { this._indicePonto++; }
    public void marcarGame(){ this._game++; }
    public void marcarTbPonto() { this._TBPonto++; }
    public string mostrarPonto() { return this.pontos[this._indicePonto]; }
    public void resetPonto() { this._indicePonto = 0; }
  }
}
