using System;
using System.Collections.ObjectModel;
using Rudo.Model;

public class Gestion
{
    public ObservableCollection<Joueur> joueurs;
    private static Gestion instance;
    public static Gestion Instance
    {
        get
        {
            if (instance == null)
                instance = new Gestion();
            return instance;
        }
        set
        {
            instance = value;
        }

    }
    public Gestion()
	{
        this.joueurs = new ObservableCollection<Joueur>();
    }
}
