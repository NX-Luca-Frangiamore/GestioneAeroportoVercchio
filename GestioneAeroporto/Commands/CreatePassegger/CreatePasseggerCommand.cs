namespace Core.Commands.CreateRoute
{
    internal class CreatePasseggerCommand
    {
        public required string Nome { get; init; }
        public required string Cognome { get; init; }
        public List<CreateLuggageCommand>? Luggages { get; init; }
        public TypeClass TypeTicket { get; init; }
        public int NSeat { get; set; }
        public int Etá { get; set; }
    }

    class CreateLuggageCommand
    {
        public float Peso {  get; init; }
        public float Dimensione {  get; init; }
    }
    enum TypeClass
    {
        Second,Primary
    }
}
