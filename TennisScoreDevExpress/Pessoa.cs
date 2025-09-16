using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreDevExpress
{
  public class Pessoa
  {
    private string _name { get; set; }
    
    public Pessoa(string nome) {
      this._name = nome;
    }

    public string Name { get => _name; }
  }
}
