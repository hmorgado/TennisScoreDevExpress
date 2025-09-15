using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  public class Jogador
  {
    public int numJogador;
    public string name;
    public bool vencedor = false;
    private int _TBPonto;

    public int GetTBPonto()
    {
      return this._TBPonto;
    }

    int indicePonto = 4;
    int game = 4;

    string[] pontos = { "0", "15", "30", "40", "vantagem" };

    public Jogador(string name, int numJogador)
    {
      this.name = name;
      this.indicePonto = 0;
      this.numJogador = numJogador;
    }
    public int GetIndicePonto()
    {
      return indicePonto;
    }
    public void SetIndicePonto(int i)
    {
      indicePonto = i;
    }
    public int GetGame()
    {
      return game;
    }
    public void SetGame(int i)
    {
      game = i;
    }
    public void marcarPonto() { this.indicePonto++; }
    public void marcarGame(){ this.game++; }
    public void marcarTbPonto() { this._TBPonto++; }
    public string mostrarPonto() { return this.pontos[this.indicePonto]; }
    public void resetPonto() { this.indicePonto = 0; }
  }
}
