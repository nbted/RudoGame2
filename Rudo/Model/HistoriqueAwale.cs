using System;
using System.Data.SQLite;
namespace Rudo.Model
{
    class HistoriqueAwale
    {
       // [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        Joueur joueur1 { get; set; }
        Joueur joueur2 { get; set; }
        String scoreFinale { get; set; }

    }
}
