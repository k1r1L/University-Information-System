namespace UniversityInformationSystem.Utillities.Exceptions
{
    using System;
    using Constants;

    public class NonExistingMessageException : Exception
    {
        public NonExistingMessageException() :
            base(ExceptionMessages.NonExistsingMessageException)
        {
            
        }
    }
}