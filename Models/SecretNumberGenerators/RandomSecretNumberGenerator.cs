using GuessNumberGame.Models.SecretNumberGenerators.Contracts;

namespace GuessNumberGame.Models.SecretNumberGenerators
{
    public class RandomSecretNumberGenerator : ISecretNumberGenerator
    {
        private readonly Random _random = new();

        public int Generate(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }
    }
}
