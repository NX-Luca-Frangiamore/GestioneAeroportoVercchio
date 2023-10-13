namespace Core.Commands.CreateRoute
{
    internal class CreatePasseggerCommand
    {
        public required string Nome { get; init; }
        public required string Cognome { get; init; }
        public List<Luggage>? Luggages { get; init; }
    }

    class Luggage
    {
        public float Peso {  get; init; }
        public float Dimensione {  get; init; }
    }
}
