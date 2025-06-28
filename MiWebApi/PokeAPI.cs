namespace espacioPokeAPI
{
    public class Pokemon
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<TipoPokemon> types { get; set; }

        public class TipoPokemon
        {
            public Tipo type { get; set; }
        }

        public class Tipo
        {
            public string name { get; set; }
        }

        public void MostrarLinea()
        {
            System.Console.WriteLine("\n---------------------\n");
        }
    }
}