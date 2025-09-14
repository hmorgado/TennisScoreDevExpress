using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  public class Jogador
  {
    public string name;
    public int indicePonto = 4;
    public int game = 5;
    public int tbPonto;

    string[] pontos = { "0", "15", "30", "40", "vantagem" };

    public Jogador(string name)
    {
      this.name = name;
      this.indicePonto = 0;
    }

    public void marcarPonto() { this.indicePonto++; }
    public void marcarGame(){ this.game++; }
    public void marcarTbPonto() { this.tbPonto++; }
    public string mostrarPonto() { return this.pontos[this.indicePonto]; }
    public void resetPonto() { this.indicePonto = 0; }
  }
}
