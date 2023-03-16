using System.Security.Claims;
using AutoMapper.Internal.Mappers;

namespace API.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static string GetUesrname(this ClaimsPrincipal user){
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
         public static string GetUserId(this ClaimsPrincipal user){
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ;
        }        
    }
}