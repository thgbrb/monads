using System;

namespace EitherStructure.Tests
{
    /// <summary>
    /// Usage cases for unit tests
    /// </summary>
    public class UsageCases
    {
        public Either<string, ArgumentNullException> ReturnsStringOrArgumentNullException(string value)
        {
            return !string.IsNullOrEmpty(value) ? value : new ArgumentNullException(nameof(value));
        }
        
        public Either<string, int> ReturnsArgumentNullExceptionForNullMembers()
        {
            return 0;
        }
    }
}