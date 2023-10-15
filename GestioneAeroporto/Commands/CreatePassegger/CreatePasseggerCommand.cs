using FluentResults;
using SimpleSoft.Mediator;
namespace Core.Commands.CreatePassegger
{
    internal class CreatePasseggerCommand: Command<Result<ResultPassegger>>
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
