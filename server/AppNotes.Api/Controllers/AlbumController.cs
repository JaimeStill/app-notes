using AppNotes.Models.Entities;
using AppNotes.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace AppNotes.Api.Controllers;

[Route("api/[controller]")]
public class AlbumController : EntityController<Album>
{
    public AlbumController(AlbumService svc)
        : base(svc) { }
}