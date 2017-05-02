namespace UniversityInformationSystem.App
{
    using System.Web;
    using System.Web.Mvc;
    using Utillities.Exceptions;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(UnauthorizedDeleteException),
                View = "CustomErrors/_UnauthorizedDeleteMessageError"
            });

            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(NonExistingMessageException),
                View = "CustomErrors/_NonExistingMessageError"
            });


            filters.Add(new HandleErrorAttribute());
        }
    }
}
