namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly birth){
            
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - birth.Year;

            if (birth > today.AddYears(-age)) age--;
            
            return age;
        }  
    }
}