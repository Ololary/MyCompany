using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

public class AdminAreaAuthorization : IControllerModelConvention
{
    private readonly string? area;
    private readonly string? policy;
    public AdminAreaAuthorization(string area, string policy)
    {
        this.area = area;
        this.policy = policy;
    }

    public void Apply(ControllerModel controller)
    {
        if (controller.Attributes.Any(el=> 
        el is AreaAttribute && (el as AreaAttribute).RouteValue.Equals(area,StringComparison.OrdinalIgnoreCase))||
        controller.RouteValues.Any(el=>el.Key.Equals("area",StringComparison.OrdinalIgnoreCase)&& el.Value.Equals(
            area,StringComparison.OrdinalIgnoreCase)))
        {
            controller.Filters.Add(new AuthorizeFilter(policy));
        }
    }

}