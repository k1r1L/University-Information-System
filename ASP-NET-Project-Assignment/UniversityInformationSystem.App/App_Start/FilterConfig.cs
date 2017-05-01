namespace UniversityInformationSystem.App
{
    using System.Web;
    using System.Web.Mvc;
    using Exceptions;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(UnauthorizedDeleteException),
                View = "_UnauthorizedDeleteMessageError"
            });

            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(NonExistingMessageException),
                View = "_NonExistingMessageError"
            });

        }
    }
}
