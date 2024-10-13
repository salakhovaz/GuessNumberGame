using GuessNumberGame.Models.SecretNumberGenerators.Contracts;

namespace GuessNumberGame.Models.SecretNumberGenerators
{
    public class FixedSecretNumberGenerator : ISecretNumberGenerator
    {
        public int Generate(int min, int max)
        {
            return 20;
        }
    }
}
