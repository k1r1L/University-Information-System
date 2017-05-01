namespace UniversityInformationSystem.App.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class NonExistingMessageException : Exception
    {
        public NonExistingMessageException() :
            base("Message with the given id does not exist!")
        {
            
        }
    }
}