namespace UniversityInformationSystem.App.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class UnauthorizedDeleteException : Exception
    {
        public UnauthorizedDeleteException() :
            base("You are not authorized to delete this message!")
        {

        }
    }
}