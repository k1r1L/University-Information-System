namespace UniversityInformationSystem.Utillities.Exceptions
{
    using System;
    using Constants;

    public class UnauthorizedDeleteException : Exception
    {
        public UnauthorizedDeleteException() :
            base(ExceptionMessages.UnauthorizedDeleteException)
        {

        }
    }
}