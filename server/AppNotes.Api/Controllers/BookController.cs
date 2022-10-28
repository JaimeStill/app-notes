using AppNotes.Models.Entities;
using AppNotes.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace AppNotes.Api.Controllers;

[Route("api/[controller]")]
public class BookController : EntityController<Book>
{
    public BookController(BookService svc)
        : base(svc) { }
}